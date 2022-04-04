using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Email do contato")]
        [EmailAddress(ErrorMessage = "O Email informado é invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage = "O Celular informado não é valido")]
        public string Celular { get; set; }
    }
}
