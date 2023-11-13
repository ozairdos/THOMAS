namespace THOMAS_WEB.NET.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        public List<EnderecoViewModel>? Logradouros { get; set; }
    }
}
