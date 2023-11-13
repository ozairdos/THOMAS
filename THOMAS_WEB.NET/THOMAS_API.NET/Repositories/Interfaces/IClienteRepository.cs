using THOMAS_API.NET.Repositories.Entities;

namespace THOMAS_API.NET.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Cliente Inserir(Cliente cliente);
        Cliente Alterar(Cliente cliente);
        List<Cliente> ConsultarAll();
        Cliente ConsultarId(int id);
        List<Cliente> ConsultarNome(string nome);
        void Delete(int id);
    }
}
