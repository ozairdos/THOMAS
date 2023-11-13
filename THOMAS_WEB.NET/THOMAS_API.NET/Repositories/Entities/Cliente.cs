namespace THOMAS_API.NET.Repositories.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }     
        public List<Endereco> Logradouros { get; set; }
    }
}
