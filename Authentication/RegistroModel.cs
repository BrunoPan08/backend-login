using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoKeener3.Authentication
{
    public class RegistroModel
    {
        [Required(ErrorMessage = "O nome é requirido")]
        public string Nome { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "O email é requirido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é requirido")]
        public string Senha { get; set; }
    }
}
