using Microsoft.AspNetCore.Mvc;
using THOMAS_API.NET.Repositories.Entities;
using THOMAS_API.NET.Repositories.Interfaces;

namespace THOMAS_API.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            this._enderecoRepository = enderecoRepository;
        }

        /// </summary>
        /// <param name="endereco"></param>
        [HttpPost]
        public ActionResult InserirEndereco(Endereco endereco)
        {
            try
            {
                var data = _enderecoRepository.Inserir(endereco);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// </summary>
        /// <param name="endereco"></param>
        [HttpPut]
        public ActionResult AlterarEndereco(Endereco endereco)
        {
            try
            {
                var data = _enderecoRepository.Alterar(endereco);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ConsultarAll")]
        public ActionResult ConsultarAllEndereco()
        {
            try
            {
                var data = _enderecoRepository.ConsultarAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// </summary>
        /// <param name="clienteId"></param>
        [HttpGet("cliente/{clienteId}")]
        public ActionResult ConsultarClienteId(int clienteId)
        {
            try
            {
                var data = _enderecoRepository.ConsultarClienteId(clienteId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// </summary>
        /// <param name="id"></param>
        [HttpGet("endereco/{id}")]
        public ActionResult ConsultarId(int id)
        {
            try
            {
                var data = _enderecoRepository.ConsultarId(id);
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
                var data = _enderecoRepository.ConsultarNome(nome);
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
        public ActionResult DeleteEndereco(int id)
        {
            try
            {
                _enderecoRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
