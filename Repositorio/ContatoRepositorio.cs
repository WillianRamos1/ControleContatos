using ControleContatos.Data;
using ControleContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarId(id);
            if (contatoDb == null) throw new System.Exception("Houve um erro ao Remover Arquivo");
            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();
            return true;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarId(contato.Id);
            if (contatoDb == null) throw new System.Exception("Houve um erro na Atualização");
            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();
            return contatoDb;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
