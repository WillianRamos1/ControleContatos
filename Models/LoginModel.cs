using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Digite seu Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite sua Senha")]
        public string Senha { get; set; }
    }
}
