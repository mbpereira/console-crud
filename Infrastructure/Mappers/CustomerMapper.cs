using ConsoleCrud.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

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
			using (var connection = (SqlConnection) _databaseConnection.GetConnection())
			using (var cmd = new SqlCommand("SELECT * FROM customers WHERE id = @id", connection))
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

			using (var connection = (SqlConnection) _databaseConnection.GetConnection())
			using (var cmd = new SqlCommand("SELECT * FROM customers", connection))
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
			using (var connection = (SqlConnection) _databaseConnection.GetConnection())
			using (var cmd = new SqlCommand(
				"INSERT INTO customers (name, email, phone) VALUES (@name, @email, @phone)",
				connection
			))
			{
				cmd.Parameters.AddWithValue("name", customer.Name);
				cmd.Parameters.AddWithValue("email", customer.Email);
				cmd.Parameters.AddWithValue("phone", customer.Phone);
				cmd.ExecuteNonQuery();
			}
			return true;
		}

		public bool Delete(int id)
		{
			using (var connection = (SqlConnection) _databaseConnection.GetConnection())
			using (var cmd = new SqlCommand("DELETE FROM customers WHERE id = @id", connection))
			{
				cmd.Parameters.AddWithValue("id", id);
				cmd.ExecuteNonQuery();
			}
			return true;
		}

		public bool Update(int id, Customer customer)
		{
			using (var connection = (SqlConnection) _databaseConnection.GetConnection())
			using (var cmd = new SqlCommand(
				"UPDATE customers SET name = @name, email = @email, phone = @phone WHERE id = @id",
				connection
			))
			{
				cmd.Parameters.AddWithValue("name", customer.Name);
				cmd.Parameters.AddWithValue("email", customer.Email);
				cmd.Parameters.AddWithValue("phone", customer.Phone);
				cmd.Parameters.AddWithValue("id", id);
				cmd.ExecuteNonQuery();
			}
			return true;
		}
	}
}