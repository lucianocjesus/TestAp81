using System;
using System.Configuration;
using System.Data.SqlClient;
using TesteAp81.Domain;

namespace TesteAp81.Data
{
	public class AdministradorData
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

					SqlDataReader reader = command.ExecuteReader();
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
	}
}
