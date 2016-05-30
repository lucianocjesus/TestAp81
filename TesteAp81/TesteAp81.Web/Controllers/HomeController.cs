using System.Web.Mvc;
using TesteAp81.Business;
using TesteAp81.Domain;
using TesteAp81.Web.Models;

namespace TesteAp81.Web.Controllers
{
	public class HomeController : Controller
	{
		private string _msgSucesso;

		public ActionResult Index(int id)
		{
			ViewBag.Id = id;
			var cliente = new ClienteBusiness().CarregaCliente(id);
			var clienteView = new ClienteViewModel
			{
				Id = cliente.Id,
				Nome = cliente.Nome,
				Email = cliente.Email,
				Senha = cliente.Senha
			};
			return View(clienteView);
		}

		[HttpPost]
		public ActionResult Index(ClienteViewModel clienteView)
		{
			if (ModelState.IsValid)
			{
				var cliente = new Cliente
				{
					Id = clienteView.Id,
					Nome = clienteView.Nome,
					Email = clienteView.Email,
					Senha = clienteView.Senha
				};
				ClienteBusiness clienteBusiness = new ClienteBusiness();
				_msgSucesso = clienteBusiness.AlteraCliente(cliente);
				Session["msgSucesso"] = _msgSucesso;
				return RedirectToAction("Mensagem", "Home");
			}
			return View(clienteView);
		}

		public ActionResult Mensagem()
		{
			ViewBag.Mensagem = Session["msgSucesso"];
			return View();
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