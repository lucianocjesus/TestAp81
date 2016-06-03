using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TesteAp81.Domain;

namespace TesteAp81.Data
{
	public class ClienteData : IDisposable
	{
		private readonly SqlConnection _objSqlConnection;

		public ClienteData()
		{
			_objSqlConnection = new SqlConnection
			{
				ConnectionString = ConfigurationManager.ConnectionStrings["TestAp81ConnectionString"].ToString()
			};
		}

		public Cliente Login(string pEmail, string pSenha)
		{
			var cliente = new Cliente();
			using (_objSqlConnection)
			{
				try
				{
					_objSqlConnection.Open();
					const string queryString = "SELECT * FROM dbo.TB_Cliente WHERE Email = @pEmail and Senha = @pSenha and Status = 1";
					var command = new SqlCommand(queryString, _objSqlConnection);
					command.Parameters.AddWithValue("@pEmail", pEmail);
					command.Parameters.AddWithValue("@pSenha", pSenha);

					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						cliente.Id = reader.GetInt32(0);
						cliente.Nome = reader.GetString(1);
						cliente.Email = reader.GetString(2);
						cliente.Senha = reader.GetString(3);
					}
				}
				finally
				{
					_objSqlConnection.Close();
				}

			}
			return cliente;
		}

		public Cliente CarregaCliente(int id)
		{
			var cliente = new Cliente();
			using (_objSqlConnection)
			{
				try
				{
					_objSqlConnection.Open();
					const string queryString = "SELECT * FROM dbo.TB_Cliente WHERE id = @pId";
					var command = new SqlCommand(queryString, _objSqlConnection);
					command.Parameters.AddWithValue("@pId", id);

					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						cliente.Id = reader.GetInt32(0);
						cliente.Nome = reader.GetString(1);
						cliente.Email = reader.GetString(2);
						cliente.Senha = reader.GetString(3);
					}
				}
				finally
				{
					_objSqlConnection.Close();
				}

			}
			return cliente;
		}

		public string AlteraCliente(Cliente cliente)
		{
			string strRetorno;
			using (_objSqlConnection)
			{
				try
				{
					_objSqlConnection.Open();
					var command = new SqlCommand();
					const string queryString =
						"Update dbo.TB_Cliente Set Nome = @pNome, Email = @pEmail, Senha = @pSenha, Status = @pStatus Where id = @pId";
					command.Connection = _objSqlConnection;
					command.CommandTimeout = 0;
					command.CommandText = queryString;
					command.CommandType = CommandType.Text;

					command.Parameters.Add("@pId", SqlDbType.Int);
					command.Parameters["@pId"].Value = cliente.Id;

					command.Parameters.Add("@pNome", SqlDbType.VarChar, 50);
					command.Parameters["@pNome"].Value = cliente.Nome;

					command.Parameters.Add("@pEmail", SqlDbType.VarChar, 100);
					command.Parameters["@pEmail"].Value = cliente.Email;

					command.Parameters.Add("@pSenha", SqlDbType.VarChar, 20);
					command.Parameters["@pSenha"].Value = cliente.Senha;

					command.Parameters.Add("@pstatus", SqlDbType.Int);
					command.Parameters["@pstatus"].Value = cliente.Status ? 1 : 0;

					command.ExecuteNonQuery();
					strRetorno = "Cliente " + cliente.Nome + " alterado com sucesso.";
				}
				catch (Exception ex)
				{
					throw new Exception("Erro ao tentar alterar o cliente " + cliente.Nome + ". Erro: " + ex.Message);
				}
				finally
				{
					_objSqlConnection.Close();
				}
			}
			return strRetorno;
		}

		public bool VerificaEmail(string pEmail)
		{
			var bExiste = false;
			using (_objSqlConnection)
			{
				try
				{
					_objSqlConnection.Open();
					const string queryString = "SELECT Email FROM dbo.TB_Cliente WHERE Email = @pEmail";
					var command = new SqlCommand(queryString, _objSqlConnection);
					command.Parameters.AddWithValue("@pEmail", pEmail);

					var reader = command.ExecuteReader();
					if (reader.Read())
						bExiste = true;

				}
				finally
				{
					_objSqlConnection.Close();
				}
			}
			return bExiste;
		}

		public List<Cliente> ListaClientes()
		{
			var lstClientes = new List<Cliente>();
			using (_objSqlConnection)
			{
				try
				{
					_objSqlConnection.Open();
					const string queryString = "SELECT * FROM dbo.TB_Cliente";
					var command = new SqlCommand(queryString, _objSqlConnection);
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						var cliente = new Cliente
						{
							Id = reader.GetInt32(0),
							Nome = reader.GetString(1),
							Email = reader.GetString(2),
							Senha = reader.GetString(3),
							Status = reader.GetInt32(4) == 1
						};
						lstClientes.Add(cliente);
					}
					reader.Close();
				}
				finally
				{
					_objSqlConnection.Close();
				}
			}
			return lstClientes;
		}

		public void InserirCliente(Cliente cliente)
		{
			using (_objSqlConnection)
			{
				try
				{
					_objSqlConnection.Open();
					var command = new SqlCommand();
					const string queryString = "Insert into dbo.TB_Cliente Values(@pNome, @pEmail, @pSenha, @pstatus)";
					command.Connection = _objSqlConnection;
					command.CommandTimeout = 0;
					command.CommandText = queryString;
					command.CommandType = CommandType.Text;

					command.Parameters.Add("@pNome", SqlDbType.VarChar, 50);
					command.Parameters["@pNome"].Value = cliente.Nome;

					command.Parameters.Add("@pEmail", SqlDbType.VarChar, 100);
					command.Parameters["@pEmail"].Value = cliente.Email;

					command.Parameters.Add("@pSenha", SqlDbType.VarChar, 20);
					command.Parameters["@pSenha"].Value = cliente.Senha;

					command.Parameters.Add("@pstatus", SqlDbType.Int);
					command.Parameters["@pstatus"].Value = cliente.Status ? 1 : 0;

					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					throw new Exception("Erro ao tentar alterar o cliente " + cliente.Nome + ". Erro: " + ex.Message);
				}
				finally
				{
					_objSqlConnection.Close();
				}
			}
		}

		public void Dispose()
		{
			_objSqlConnection.Close();
		}
	}
}
