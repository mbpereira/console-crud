using ConsoleCrud.Factories;
using ConsoleCrud.Infrastructure.Extensions;
using ConsoleCrud.Models;
using System.Collections.Generic;

namespace ConsoleCrud.Infrastructure.Mappers
{
	public class CustomerMapper : ICustomerMapper
	{
		private readonly DatabaseConnection _databaseConnection;
		public CustomerMapper(DatabaseConnection databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public Customer FindByInd(int id)
		{
			using (var connection = _databaseConnection.GetConnection())
			using (var cmd = CommandFactory.CreateCommand("SELECT * FROM customers WHERE id = @id", connection))
			using (var reader = cmd.ExecuteReader())
			{
				Customer customer = new Customer();
				customer.Name = reader["name"].ToString();
				customer.Email = reader["email"].ToString();
				customer.Phone = reader["phone"].ToString();
				return customer;
			}
		}

		public List<Customer> All()
		{
			List<Customer> customers = new List<Customer>();

			using (var connection = _databaseConnection.GetConnection())
			using (var cmd = CommandFactory.CreateCommand("SELECT * FROM customers", connection))
			using (var reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					Customer customer = new Customer();

					customer.Id = int.Parse(reader["id"].ToString());
					customer.Name = reader["name"].ToString();
					customer.Email = reader["email"].ToString();
					customer.Phone = reader["phone"].ToString();

					customers.Add(customer);
				}
			}

			return customers;
		}

		public bool Save(Customer customer)
		{
			using (var connection = _databaseConnection.GetConnection())
			using (var cmd = CommandFactory.CreateCommand(
				"INSERT INTO Customers (name, email, phone) VALUES (@name, @email, @phone)",
				connection
			))
			{
				cmd.AddParameter("name", System.Data.DbType.String, customer.Name);
				cmd.AddParameter("email", System.Data.DbType.String, customer.Email);
				cmd.AddParameter("phone", System.Data.DbType.String, customer.Phone);
				cmd.ExecuteNonQuery();
			}
			return true;
		}

		public bool Delete(int id)
		{
			using (var connection = _databaseConnection.GetConnection())
			using (var cmd = CommandFactory.CreateCommand("DELETE FROM customers WHERE id = @id", connection))
			{
				cmd.AddParameter("id", System.Data.DbType.String, id);
				cmd.ExecuteNonQuery();
			}
			return true;
		}

		public bool Update(int id, Customer customer)
		{
			using (var connection = _databaseConnection.GetConnection())
			using (var cmd = CommandFactory.CreateCommand(
				"UPDATE customers SET name = @name, email = @email, phone = @phone WHERE id = @id",
				connection
			))
			{
				cmd.AddParameter("name", System.Data.DbType.String, customer.Name);
				cmd.AddParameter("email", System.Data.DbType.String, customer.Email);
				cmd.AddParameter("phone", System.Data.DbType.String, customer.Phone);
				cmd.AddParameter("id", System.Data.DbType.String, id);
				cmd.ExecuteNonQuery();
			}
			return true;
		}
	}
}