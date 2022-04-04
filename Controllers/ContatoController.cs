using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato removido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi possivel excluir o Contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception Erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel excluir o Contato, Detalhes do Erro:{Erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }
                else return View(contato);
            }
            catch (Exception Erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o Contato, Detalhes do Erro:{Erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com Sucesso";
                    return RedirectToAction("Index");
                }
                else return View("Editar", contato);
            }
            catch (Exception Erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel alterar o Contato, Detalhes do Erro:{Erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
