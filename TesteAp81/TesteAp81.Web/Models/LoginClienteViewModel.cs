using System;
using System.ComponentModel.DataAnnotations;

namespace TesteAp81.Web.Models
{
    public class LoginClienteViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Por favor preencher o campo E-mail.")]
        [StringLength(100, ErrorMessage = "Maximo de 100 caracteres.")]
        [RegularExpression(@"^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$", ErrorMessage = "Formato de email não reconhecido. Por favor corrigir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor preencher o campo Senha.")]
        [StringLength(20, ErrorMessage = "Maximo de 20 caracteres.")]
        public String Senha { get; set; }
        public bool EsqueciSenha { get; set; }
        public string Mensagem { get; set; }
    }
}