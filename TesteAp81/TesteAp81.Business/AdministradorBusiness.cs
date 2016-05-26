using TesteAp81.Data;
using TesteAp81.Domain;

namespace TesteAp81.Business
{
	public class AdministradorBusiness
	{
		public Administrador AcessoIntranet(string pCodigo)
		{
			var administrador = new AdministradorData().AcessoIntranet(pCodigo);
			return administrador;
		}
	}
}
