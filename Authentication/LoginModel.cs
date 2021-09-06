using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoKeener3.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O nome é requirido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A senha é requirido")]
        public string Senha { get; set; }
    }
}
