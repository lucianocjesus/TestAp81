using System;
using System.Collections.Generic;
using TesteAp81.Business.Contracts;
using TesteAp81.Data;
using TesteAp81.Domain;

namespace TesteAp81.Business
{
	public class AdministradorBusiness : IAdministradorBusinessRepository
	{
		public Administrador AcessoIntranet(string pCodigo)
		{
			var administrador = new AdministradorData().AcessoIntranet(pCodigo);
			return administrador;
		}

		public List<Administrador> Get()
		{
			return new AdministradorData().Get();
		}

		public Administrador Get(string codigo)
		{
			var administrador = new AdministradorData().Get(codigo);
			return administrador;
		}

		public bool Update(Administrador cliente)
		{
			throw new NotImplementedException();
		}

		public bool Create(Administrador cliente)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
