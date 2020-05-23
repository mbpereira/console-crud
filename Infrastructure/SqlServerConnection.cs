using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleCrud.Infrastructure
{
	public class SqlServerConnection : DatabaseConnection
	{
		protected override IDbConnection CreateConnection()
		{
			return new SqlConnection(Env.GetInstance().Get("connectionString"));
		}
	}
}
