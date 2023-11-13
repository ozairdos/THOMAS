using Microsoft.AspNetCore.Mvc;
using PagedList;
using THOMAS_WEB.NET.Models;

namespace THOMAS_WEB.NET.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index(int? pagina)
        {
            int paginaTamanho = 4;
            int paginaNumero = (pagina ?? 1);

            IEnumerable<ClienteViewModel> clientes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/");

                //HTTP GET
                var responseTask = client.GetAsync("Cliente/ConsultarAll");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ClienteViewModel>>();
                    readTask.Wait();
                    clientes = readTask.Result;
                }
                else
                {
                    clientes = Enumerable.Empty<ClienteViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(clientes.ToPagedList(paginaNumero, paginaTamanho));
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/Cliente");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<ClienteViewModel>("", cliente);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(cliente);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ClienteViewModel cliente = null;
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
                    cliente = readTask.Result;
                }
            }
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/");
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<ClienteViewModel>("Cliente", cliente);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ClienteViewModel cliente = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/");
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Cliente/?id=" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ClienteViewModel contato = null;
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
            }
            return View(contato);
        }
        public ActionResult Search(string nome)
        {
            IEnumerable<ClienteViewModel> cliente = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7175/Cliente/");
                //HTTP GET
                var responseTask = client.GetAsync("api/" + nome);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ClienteViewModel>>();
                    readTask.Wait();
                    cliente = readTask.Result;
                }
                else
                {
                    cliente = Enumerable.Empty<ClienteViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(cliente);
            }
        }
    }
}
