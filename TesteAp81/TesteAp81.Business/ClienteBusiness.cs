using System;
using System.Collections.Generic;
using TesteAp81.Business.Contracts;
using TesteAp81.Data;
using TesteAp81.Domain;

namespace TesteAp81.Business
{
	public class ClienteBusiness : IClienteBusinessRepository
	{

		public List<Cliente> ListaClientes()
		{
			List<Cliente> lstClientes = new ClienteData().ListaClientes();
			return lstClientes;
		}

        //public Cliente Login(string pEmail, string pSenha)
        //{
        //    var cliente = new ClienteData().Login(pEmail, pSenha);
        //    if (cliente.Id == 0)
        //    {
        //        throw new Exception("Não foi possivel conectar. Entre em contato com o administrador.");
        //    }
        //    return cliente;
        //}

		public Cliente CarregaCliente(int id)
		{
			var cliente = new ClienteData().CarregaCliente(id);
			return cliente;
		}

		public void InserirCliente(Cliente cliente)
		{
			new ClienteData().InserirCliente(cliente);

		}

		public string AlteraCliente(Cliente cliente)
		{
			try
			{
				var msgRetorno = new ClienteData().AlteraCliente(cliente);
				return msgRetorno;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

        //public string VerificaEmail(string pEmail)
        //{
        //    string strRetorno = null;
        //    try
        //    {
        //        bool bExiste = new ClienteData().VerificaEmail(pEmail);
        //        if (bExiste)
        //        {
        //            //Configurar o envio do email aqui.
        //            strRetorno = "E-mail enviado com sucesso para o endereço: " + pEmail;
        //        }
        //        else
        //        {
        //            strRetorno = "Este e-mail não esta cadastrado no sistema.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        strRetorno = ex.Message;
        //    }
        //    return strRetorno;
        //}

		public List<Cliente> Get()
		{
			List<Cliente> lstClientes = new ClienteData().ListaClientes();
			return lstClientes;
		}

		public Cliente GetLogin(string email, string password)
		{
			var cliente = new ClienteData().Login(email, password);
			if (cliente.Id == 0)
			{
				throw new Exception("Não foi possivel conectar. Entre em contato com o administrador.");
			}
			return cliente;
		}

		public string GetEmail(string email)
		{
		    string msg;
            bool retorno = new ClienteData().VerificaEmail(email);
            if (!retorno)
            {
                msg = "Este e-mail não esta cadastrado no sistema.";
            }
            else
            {
                msg = "E-mail enviado com sucesso para o endereço: " + email;
            }
		    return msg;

		}

		public Cliente Get(int id)
		{
            var cliente = new ClienteData().CarregaCliente(id);
            return cliente;
		}

		public bool Create(Cliente cliente)
		{
		    try
		    {
                new ClienteData().InserirCliente(cliente);
		        return true;
		    }
		    catch
		    {
		        return false;
		    }
            
		}

		public bool Update(Cliente cliente)
		{
            try
            {
                new ClienteData().AlteraCliente(cliente);
                return true;
            }
            catch
            {
                return false;
            }
		}

		public void Delete(int id)
		{
            throw new NotImplementedException();
		}

		public void Dispose()
		{
			
		}
	}
}
