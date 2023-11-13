using Microsoft.AspNetCore.Mvc;
using THOMAS_API.NET.Repositories.Entities;
using THOMAS_API.NET.Repositories.Interfaces;

namespace THOMAS_API.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        /// </summary>
        /// <param name="cliente"></param>
        [HttpPost]
        public ActionResult InserirCliente(Cliente cliente)
        {
            try
            {
                var data = _clienteRepository.Inserir(cliente);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// </summary>
        /// <param name="cliente"></param>
        [HttpPut]
        public ActionResult AlterarCliente(Cliente cliente)
        {
            try
            {
                var data = _clienteRepository.Alterar(cliente);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("ConsultarAll")]
        public ActionResult ConsultarAllCliente()
        {
            try
            {
                var data = _clienteRepository.ConsultarAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
   
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public ActionResult ConsultarId(int id)
        {
            try
            {
                var data = _clienteRepository.ConsultarId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// </summary>
        /// <param name="nome"></param>
        [Route("api/{nome}")]
        [HttpGet]
        public ActionResult ConsultarNome(string nome)
        {
            try
            {
                var data = _clienteRepository.ConsultarNome(nome);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public ActionResult DeleteCliente(int id)
        {
            try
            {
                _clienteRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
