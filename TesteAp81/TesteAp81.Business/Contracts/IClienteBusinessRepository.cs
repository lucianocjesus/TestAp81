using System;
using System.Collections.Generic;
using TesteAp81.Domain;

namespace TesteAp81.Business.Contracts
{
	public interface IClienteBusinessRepository : IDisposable
	{
		List<Cliente> Get();
		Cliente GetLogin(string email, string password);
		string GetEmail(string email);
		Cliente Get(int id);
		bool Create(Cliente cliente);
		bool Update(Cliente cliente);
		void Delete(int id);
	}
}
