using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TesteAp81.Business;

namespace TesteAp81.Intranet
{
	public class MvcApplication : HttpApplication
	{
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
			if (windowsIdentity != null)
			{
				var acesso = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["isDebug"]) ? ConfigurationManager.AppSettings["isDebug"] : windowsIdentity.Name;
				var adm = new AdministradorBusiness().AcessoIntranet(acesso.Split('\\')[1]);
				Session["userCodigo"] = adm.Codigo;
				Session["UserNome"] = adm.Nome;
				Session["UserDepartamento"] = adm.Departamento;
			}
		}
	}
}
