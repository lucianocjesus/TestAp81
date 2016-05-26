using System;
using System.Collections.Generic;
using TesteAp81.Data;
using TesteAp81.Domain;

namespace TesteAp81.Business
{
    public class ClienteBusiness
    {
        public Cliente Login(string pEmail, string pSenha)
        {
            var cliente = new ClienteData().Login(pEmail,pSenha);
            if (cliente.Id==0)
            {
                throw new Exception("Não foi possivel conectar. Entre em contato com o administrador.");
            }
            return cliente;
        }

        public Cliente CarregaCliente(int id)
        {
            var cliente = new ClienteData().CarregaCliente(id);
            return cliente;
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

        public string VerificaEmail(string pEmail)
        {
            string strRetorno = null;
            try
            {
                bool bExiste = new ClienteData().VerificaEmail(pEmail);
                if (bExiste)
                {
                    //Configurar o envio do email aqui.
                    strRetorno = "E-mail enviado com sucesso para o endereço: " + pEmail;
                }
                else
                {
                    strRetorno = "Este e-mail não esta cadastrado no sistema.";
                }
            }
            catch (Exception ex)
            {
                strRetorno = ex.Message;
            }
            return strRetorno;
        }

        public List<Cliente> ListaClientes()
        {
            List<Cliente> lstClientes = new ClienteData().ListaClientes();
            return lstClientes;
        }

        public void InserirCliente(Cliente cliente)
        {
            new ClienteData().InserirCliente(cliente);

        }
    }
}
