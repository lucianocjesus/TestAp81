using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TesteAp81.Business;
using TesteAp81.Business.Contracts;

namespace TesteAp81.Intranet
{
	public class MvcApplication : HttpApplication
	{
		private IAdministradorBusinessRepository _repository;
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		protected void Session_Start()
		{
			var windowsIdentity = WindowsIdentity.GetCurrent();
			_repository = new AdministradorBusiness();

			if (windowsIdentity != null)
			{
				var acesso = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["isDebug"]) ? ConfigurationManager.AppSettings["isDebug"] : windowsIdentity.Name;
				//var acesso = windowsIdentity.Name;

				var adm = _repository.Get(acesso.Split('\\')[1]);
				Session["userCodigo"] = adm.Codigo;
				Session["UserNome"] = windowsIdentity.Name.Split('\\')[1];
				Session["UserDepartamento"] = adm.Departamento;
			}
		}
	}
}
