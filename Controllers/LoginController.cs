using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarLogin(loginModel.Login);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "A Senha do usuario é invalida, Por Favor Tente Novamente.";
                    } 
                    TempData["MensagemErro"] = "Usuario e/ou Senha Invalido(s). Por Favor Tente Novamente.";
                }
                return View("Index");
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Não foi Possivel fazer o Login, Tente Novamente";
                return RedirectToAction("Index");
            }
        }
    }
}
