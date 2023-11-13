using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using PagedList;
using THOMAS_WEB.NET.Models;

namespace THOMAS_WEB.NET.Controllers
{
    public class EnderecoController : Controller
    {
        public ActionResult Index(int? pagina, int id)
        {
            ClienteViewModel contato = new ClienteViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/Cliente/");

                //HTTP GET
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClienteViewModel>();
                    readTask.Wait();
                    contato = readTask.Result;
                }               

                return View(contato);
            }
        }

        [HttpGet]
        public ActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(EnderecoViewModel endereco)
        {
            if (endereco == null)
            {
                return BadRequest();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/Endereco");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<EnderecoViewModel>("", endereco);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { id = endereco.Id });
                }
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(endereco);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            EnderecoViewModel endereco = new EnderecoViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/Endereco/endereco/");

                //HTTP GET
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EnderecoViewModel>();
                    readTask.Wait();
                    endereco = readTask.Result;                    
                }
            }            
            return View(endereco);
        }
        public ActionResult EditIdCliente(int clienteId)
        {
            if (clienteId == null)
            {
                return BadRequest();
            }
            EnderecoViewModel endereco = new EnderecoViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/");

                //HTTP GET
                var responseTask = client.GetAsync(clienteId.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EnderecoViewModel>();
                    readTask.Wait();
                    endereco = readTask.Result;
                }
            }
            return View(endereco);
        }
        [HttpPost]
        public ActionResult Edit(EnderecoViewModel endereco)
        {
            if (endereco == null)
            {
                return BadRequest();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/");
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<EnderecoViewModel>("Endereco", endereco);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EnderecoViewModel>();
                    readTask.Wait();
                    endereco = readTask.Result;
                    return RedirectToAction("Index", new { id = endereco.ClienteId });
                }               
            }
            return View(endereco);
        }
        [HttpGet]
        public ActionResult Delete(int? id, int clienteId)
        {
            if (id == null)
            {
                return BadRequest();
            }
            EnderecoViewModel endereco = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/");
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Endereco/?id=" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { id = clienteId });
                }
            }
            return View(endereco);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            EnderecoViewModel endereco = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/Endereco/endereco/");

                //HTTP GET
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EnderecoViewModel>();
                    readTask.Wait();
                    endereco = readTask.Result;
                }
            }
            return View(endereco);
        }
        public ActionResult Search(string nome)
        {
            IEnumerable<EnderecoViewModel> endereco = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/Cliente/");
                //HTTP GET
                var responseTask = client.GetAsync("api/" + nome);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EnderecoViewModel>>();
                    readTask.Wait();
                    endereco = readTask.Result;
                }
                else
                {
                    endereco = Enumerable.Empty<EnderecoViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(endereco);
            }
        }
    }
}
