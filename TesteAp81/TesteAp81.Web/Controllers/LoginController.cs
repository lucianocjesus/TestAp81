using System;
using System.Web.Mvc;
using TesteAp81.Business;
using TesteAp81.Business.Contracts;
using TesteAp81.Web.Models;

namespace TesteAp81.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IClienteBusinessRepository _repository;

        public LoginController()
        {
            _repository = new ClienteBusiness();
        }

        public ActionResult Index()
        {
            var loginClienteView = new LoginClienteViewModel();
            return View(loginClienteView);
        }

        [HttpPost]
        public ActionResult Index(LoginClienteViewModel loginCliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var cliente = new ClienteBusiness().Login(loginCliente.Email, loginCliente.Senha);
                    //var cliente = new ClienteBusiness().GetLogin(loginCliente.Email, loginCliente.Senha);
                    var cliente = _repository.GetLogin(loginCliente.Email, loginCliente.Senha);
                    var clienteView = new ClienteViewModel
                    {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        Senha = cliente.Senha
                    };
                    return RedirectToAction("Index", "Home", new { id = clienteView.Id });
                }
                catch (Exception ex)
                {
                    loginCliente.Mensagem = ex.Message;
                }
            }
            return View(loginCliente);
        }

        public ActionResult EsqueciSenha()
        {
            var loginClienteView = new LoginClienteViewModel();
            return View(loginClienteView);
        }

        [HttpPost]
        public ActionResult EsqueciSenha(LoginClienteViewModel loginCliente)
        {
            if (loginCliente.Email!=null)
            {
                loginCliente.Mensagem = _repository.GetEmail(loginCliente.Email);
            }
            return View(loginCliente);
        }
    }
}