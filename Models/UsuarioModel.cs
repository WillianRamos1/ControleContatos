using ControleContatos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Login do Usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o Email do Usuario")]
        [EmailAddress(ErrorMessage = "O Email informado é invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do Usuario")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite a Senha do Usuario")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
