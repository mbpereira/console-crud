using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleCrud.Factories
{
	public class CommandFactory
	{
		public static IDbCommand CreateCommand(string commandText, IDbConnection connection)
		{
			return new SqlCommand(commandText, (SqlConnection) connection);
		}
	}
}
