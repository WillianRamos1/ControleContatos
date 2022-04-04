using ControleContatos.Data;
using ControleContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarId(id);
            if (usuarioDb == null) throw new System.Exception("Houve um erro ao Remover Arquivo");
            _bancoContext.Usuarios.Remove(usuarioDb);
            _bancoContext.SaveChanges();
            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarId(usuario.Id);
            if (usuarioDb == null) throw new System.Exception("Houve um erro na Atualização");
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAlteracao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();
            return usuarioDb;
        }

        public UsuarioModel BuscarLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel ListarId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
