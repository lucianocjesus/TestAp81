using System.ComponentModel.DataAnnotations;

namespace TesteAp81.Intranet.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor preencher o campo Nome.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor preencher o campo E-mail.")]
        [RegularExpression(@"^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$", ErrorMessage = "Formato de email não reconhecido. Por favor corrigir.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor preencher o campo E-mail.")]
        public string Senha { get; set; }
        public bool Status { get; set; }
    }
}