using System.Collections.Generic;
using TesteAp81.Domain;

namespace TesteAp81.Business.Contracts
{
	public interface IAdministradorBusinessRepository
	{
		List<Administrador> Get();
		Administrador Get(string codigo);
		bool Create(Administrador cliente);
		bool Update(Administrador cliente);
		void Delete(int id);
	}
}
