using System.Collections.Generic;
using System.Web.Mvc;
using TesteAp81.Business;
using TesteAp81.Domain;
using TesteAp81.Intranet.Models;

namespace TesteAp81.Intranet.Controllers
{
    public class HomeController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["userCodigo"] == null && Session["UserNome"] == null) return;
            ViewBag.userCodigo = Session["userCodigo"];
            ViewBag.UserNome = Session["UserNome"];
            ViewBag.UserDepartamento = Session["UserDepartamento"];
        }

        public ActionResult Index(ClienteViewModel clienteView)
        {
            List<ClienteViewModel> lstList = new List<ClienteViewModel>();
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            var lstClientes = clienteBusiness.ListaClientes();
            foreach (Cliente c in lstClientes)
            {
                clienteView = new ClienteViewModel();
                clienteView.Id = c.Id;
                clienteView.Nome = c.Nome;
                clienteView.Email = c.Email;
                clienteView.Status = c.Status;
                lstList.Add(clienteView);
            }

            return View(lstList);
        }

        public ActionResult AdicionarCliente()
        {
            var clienteView = new ClienteViewModel();
            return View(clienteView);
        }

        [HttpPost]
        public ActionResult AdicionarCliente(ClienteViewModel clienteView)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente
                {
                    Nome = clienteView.Nome,
                    Email = clienteView.Email,
                    Senha = clienteView.Senha,
                    Status = clienteView.Status
                };
                new ClienteBusiness().InserirCliente(cliente);
                return RedirectToAction("Index", "Home");
            }
            return View(clienteView);
        }

        public ActionResult EditarCliente(int id)
        {
            var cliente = new ClienteBusiness().CarregaCliente(id);
            var clienteView = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Senha = cliente.Senha,
                Status = cliente.Status
            };
            return View(clienteView);
        }

        [HttpPost]
        public ActionResult EditarCliente(ClienteViewModel clienteView)
        {
            Cliente cliente = new Cliente
            {
                Id = clienteView.Id,
                Nome = clienteView.Nome,
                Email = clienteView.Email,
                Senha = clienteView.Senha,
                Status = clienteView.Status
            };

            ClienteBusiness clienteBusiness = new ClienteBusiness();
            clienteBusiness.AlteraCliente(cliente);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}