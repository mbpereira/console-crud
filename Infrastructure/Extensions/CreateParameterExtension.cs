using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleCrud.Infrastructure.Extensions
{
	public static class CreateParameterExtension
	{
		public static void AddParameter(this IDbCommand cmd, string parameterName, DbType dbType, object value)
		{
			var parameter = cmd.CreateParameter();
			parameter.DbType = dbType;
			parameter.ParameterName = parameterName;
			parameter.Value = value;

			cmd.Parameters.Add(parameter);
		}
	}
}
