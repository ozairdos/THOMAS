using THOMAS_API.NET.Repositories.Entities;

namespace THOMAS_API.NET.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Endereco Inserir(Endereco endereco);
        Endereco Alterar(Endereco endereco);
        List<Endereco> ConsultarAll();
        List<Endereco> ConsultarClienteId(int id);
        Endereco ConsultarId(int id);
        List<Endereco> ConsultarNome(string nome);
        void Delete(int id);
    }
}
