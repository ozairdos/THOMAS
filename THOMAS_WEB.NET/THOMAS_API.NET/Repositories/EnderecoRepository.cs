using THOMAS_API.NET.Repositories.Contexto;
using THOMAS_API.NET.Repositories.Entities;
using THOMAS_API.NET.Repositories.Interfaces;

namespace THOMAS_API.NET.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        protected readonly Context _contexto;

        public EnderecoRepository(Context contexto)
        {
            _contexto = contexto;
        }

        public Endereco Inserir(Endereco endereco)
        {
            try
            {
                endereco.ClienteId = endereco.Id;
                endereco.Id = 0;

                _contexto.tblEndereco.Add(endereco);
                _contexto.SaveChanges();
                return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Endereco Alterar(Endereco endereco)
        {
            try
            {
                var entity = _contexto.tblEndereco.Where(x => x.Id == endereco.Id).FirstOrDefault();
                entity.Logradouro = endereco.Logradouro;

                _contexto.tblEndereco.Update(entity);
                _contexto.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Endereco> ConsultarAll()
        {
            try
            {
                var entity = _contexto.tblEndereco.ToList();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Endereco> ConsultarClienteId(int id)
        {
            try
            {
                var entity = _contexto.tblEndereco.Where(x => x.ClienteId == id).ToList();
                if (entity == null) throw new Exception("Não encontrado registro");
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Endereco ConsultarId(int id)
        {
            try
            {
                var endereco = _contexto.tblEndereco.Where(x => x.Id == id).First();
                if (endereco == null) throw new Exception("Não encontrado registro");
                return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Endereco> ConsultarNome(string nome)
        {
            try
            {
                var entity = _contexto.tblEndereco.Where(x => x.Logradouro.Contains(nome)).ToList();
                if (entity == null) throw new Exception("Não encontrado registro");               

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var entity = _contexto.tblEndereco.Where(x => x.Id == id).FirstOrDefault();
                if (entity == null) throw new Exception("Não encontrado registro para deletar");

                _contexto.tblEndereco.Remove(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
