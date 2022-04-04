using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarId(id);
            return View(usuario);
        }
        public IActionResult ApagarConfirmar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };
                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com Sucesso";
                    return RedirectToAction("Index");
                }
                else return View("Editar", usuario);
            }
            catch (Exception Erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel alterar o Usuario, Detalhes do Erro:{Erro.Message}";
                return RedirectToAction("Index");
            }
        }
            public IActionResult Apagar(int id)
            {
                try
                {
                    bool apagado = _usuarioRepositorio.Apagar(id);

                    if (apagado)
                    {
                        TempData["MensagemSucesso"] = "Usuario removido com Sucesso";
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Não foi possivel excluir o Usuario";
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception Erro)
                {

                    TempData["MensagemErro"] = $"Não foi possivel cadastrar o Usuario, Detalhes do Erro:{Erro.Message}";
                    return RedirectToAction("Index");
                }
            }
            [HttpPost]
            public IActionResult Criar(UsuarioModel usuario)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _usuarioRepositorio.Adicionar(usuario);
                        TempData["MensagemSucesso"] = "Usuario Cadastrado com Sucesso";
                        return RedirectToAction("Index");
                    }
                    else return View(usuario);
                }
                catch (Exception Erro)
                {
                    TempData["MensagemErro"] = $"Não foi possivel cadastrar seu Usuario, Detalhes do Erro:{Erro.Message}";
                    return RedirectToAction("Index");
                }
            }
        }
    }
