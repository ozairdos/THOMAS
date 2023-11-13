using THOMAS_API.NET.Repositories.Contexto;
using THOMAS_API.NET.Repositories.Entities;
using THOMAS_API.NET.Repositories.Interfaces;

namespace THOMAS_API.NET.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly Context _contexto;

        public ClienteRepository(Context contexto)
        {
            _contexto = contexto;
        }
        public Cliente Inserir(Cliente cliente)
        {
            try
            {
                _contexto.tblCliente.Add(cliente);
                _contexto.SaveChanges();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        public Cliente Alterar(Cliente cliente)
        {
            try
            {
                var entityCliente = _contexto.tblCliente.Where(x => x.Id == cliente.Id).FirstOrDefault();
                entityCliente.Nome = cliente.Nome;
                entityCliente.Email = cliente.Email;
                entityCliente.Logotipo = cliente.Logotipo;
                var entityEndereco = _contexto.tblEndereco.Where(x => x.ClienteId == entityCliente.Id).FirstOrDefault();
                entityEndereco.Logradouro = cliente.Logradouros.Select(x => x.Logradouro).First();
                entityCliente.Logradouros[0] = entityEndereco;

                _contexto.tblCliente.Update(entityCliente);
                _contexto.SaveChanges();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Cliente> ConsultarAll()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                var entity = _contexto.tblCliente.ToList();

                foreach (var item in entity)
                {
                    item.Logradouros = _contexto.tblEndereco.Where(x => x.ClienteId == item.Id).ToList();
                    clientes.Add(item);
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Cliente ConsultarId(int id)
        {
            try
            {
                var entity = _contexto.tblCliente.Where(x => x.Id == id).FirstOrDefault();
                if (entity == null) throw new Exception("Não encontrado registro");

                entity.Logradouros = _contexto.tblEndereco.Where(x => x.ClienteId == entity.Id).ToList();
                return entity;               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Cliente> ConsultarNome(string nome)
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                var entity = _contexto.tblCliente.Where(x => x.Nome.Contains(nome)).ToList();
                if (entity == null) throw new Exception("Não encontrado registro");

                foreach (var item in entity)
                {
                    item.Logradouros = _contexto.tblEndereco.Where(x => x.ClienteId == item.Id).ToList();
                    clientes.Add(item);
                }

                return clientes;
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
                var entity = _contexto.tblCliente.Where(x => x.Id == id).FirstOrDefault();                
                if (entity == null) throw new Exception("Não encontrado registro para deletar");

                _contexto.tblCliente.Remove(entity);
                _contexto.SaveChanges();                           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
