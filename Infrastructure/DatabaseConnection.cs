using System.Data;

namespace ConsoleCrud.Infrastructure
{
	public abstract class DatabaseConnection
    {
		protected abstract IDbConnection CreateConnection();

		public IDbConnection GetConnection()
		{
			var connection = CreateConnection();
			connection.Open();

			return connection;
		}
    }
}