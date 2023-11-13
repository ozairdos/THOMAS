using System.ComponentModel;

namespace THOMAS_WEB.NET.Models
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public int ClienteId { get; set; }
    }
}
