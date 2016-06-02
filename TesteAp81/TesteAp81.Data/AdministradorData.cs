using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TesteAp81.Domain;

namespace TesteAp81.Data
{
	public class AdministradorData : IDisposable
	{
		private readonly SqlConnection _objSqlConnection;

		public AdministradorData()
		{
			_objSqlConnection = new SqlConnection
			{
				ConnectionString = ConfigurationManager.ConnectionStrings["TestAp81ConnectionString"].ToString()
			};
		}

		public Administrador AcessoIntranet(string pCodigo)
		{
			var administrador = new Administrador();
			using (_objSqlConnection)
			{
				try
				{
					_objSqlConnection.Open();
					const string queryString = "SELECT * FROM dbo.TB_Administracao WHERE Codigo = @pCodigo";
					var command = new SqlCommand(queryString, _objSqlConnection);
					command.Parameters.AddWithValue("@pCodigo", pCodigo);

					var reader = command.ExecuteReader();

					if (reader.Read())
					{
						administrador.Id = reader.GetInt32(0);
						administrador.Codigo = reader.GetString(1);
						administrador.Nome = reader.GetString(2);
						administrador.Email = reader.GetString(3);
						administrador.Cargo = reader.GetString(4);
						administrador.Departamento = reader.GetString(5);
					}
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					_objSqlConnection.Close();
				}

			}
			return administrador;
		}

		public Administrador Get(string codigo)
		{
			var administrador = new Administrador();
			using (_objSqlConnection)
			{
				try
				{
					_objSqlConnection.Open();
					const string queryString = "SELECT * FROM dbo.TB_Administracao WHERE Codigo = @pCodigo";
					var command = new SqlCommand(queryString, _objSqlConnection);
					command.Parameters.AddWithValue("@pCodigo", codigo);

					var reader = command.ExecuteReader();

					if (reader.Read())
					{
						administrador.Id = reader.GetInt32(0);
						administrador.Codigo = reader.GetString(1);
						administrador.Nome = reader.GetString(2);
						administrador.Email = reader.GetString(3);
						administrador.Cargo = reader.GetString(4);
						administrador.Departamento = reader.GetString(5);
					}
				}
				catch
				{
					administrador = null;
				}
				finally
				{
					_objSqlConnection.Close();
				}
			}
			return administrador;
		}

		public List<Administrador> Get()
		{
			var lstAdministradors = new List<Administrador>();
			using (_objSqlConnection)
			{
				try
				{
					_objSqlConnection.Open();
					const string queryString = "SELECT * FROM dbo.TB_Administracao";
					var command = new SqlCommand(queryString, _objSqlConnection);

					var reader = command.ExecuteReader();

					while (reader.Read())
					{
						var administrador = new Administrador
						{
							Id = reader.GetInt32(0),
							Codigo = reader.GetString(1),
							Nome = reader.GetString(2),
							Email = reader.GetString(3),
							Cargo = reader.GetString(4),
							Departamento = reader.GetString(5)
						};
						lstAdministradors.Add(administrador);
					}

				}
				catch
				{
					lstAdministradors = null;
				}
				finally
				{
					_objSqlConnection.Close();
				}
			}
			return lstAdministradors;
		}

		public void Dispose()
		{
			_objSqlConnection.Close();
		}
	}
}
