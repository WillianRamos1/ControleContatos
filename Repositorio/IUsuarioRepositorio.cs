using ControleContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarLogin(string login);
        UsuarioModel ListarId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
    }
}