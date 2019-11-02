using crud.Models;
using Npgsql;
using System.Collections.Generic;

namespace crud.Repositories
{
    public class CustomerRepo
    {
        private static readonly DB _db = DB.Instance;
        public CustomerRepo() {
            _db.Connection.Open();
        }

        public Customer FindByInd(int id) {
            using(var cmd = new NpgsqlCommand("SELECT * FROM customers WHERE id = @id", _db.Connection))
            using(var reader = cmd.ExecuteReader()) {
                Customer customer = new Customer();
                customer.Name = reader["name"].ToString();
                customer.Email = reader["email"].ToString();
                customer.Phone = reader["phone"].ToString();
                _db.Connection.Close();
                return customer;
            }
        }

        public List<Customer> All() {
            List<Customer> customers = new List<Customer>();

            using (var cmd = new NpgsqlCommand("SELECT * FROM customers", _db.Connection))
            using (var reader = cmd.ExecuteReader()) {
                while(reader.Read()) {
                    Customer customer = new Customer();

                    customer.Id = int.Parse(reader["id"].ToString());
                    customer.Name = reader["name"].ToString();
                    customer.Email = reader["email"].ToString();
                    customer.Phone = reader["phone"].ToString();

                    customers.Add(customer);
                }
                _db.Connection.Close();
            }

            return customers;
        }

        public bool Save(Customer customer) {
            using (var cmd = new NpgsqlCommand(
                "INSERT INTO customers (name, email, phone) VALUES (@name, @email, @phone)",
                _db.Connection
            )) {
                cmd.Parameters.AddWithValue("name", customer.Name);
                cmd.Parameters.AddWithValue("email", customer.Phone);
                cmd.Parameters.AddWithValue("phone", customer.Email);
                cmd.ExecuteNonQuery();
                _db.Connection.Close();
            }
            return true;
        }

        public bool Delete(int id) {
            using (var cmd = new NpgsqlCommand("DELETE FROM customers WHERE id = @id", _db.Connection)) {
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                _db.Connection.Close();
            }
            return true;
        }

        public bool Update(int id, Customer customer) {
            using(var cmd = new NpgsqlCommand(
                "UPDATE customers SET name = @name, email = @email, phone = @phone WHERE id = @id", 
                _db.Connection
            )) {
                cmd.Parameters.AddWithValue("name", customer.Name);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("phone", customer.Phone);
                cmd.ExecuteNonQuery();
                _db.Connection.Close();
            }
            return true;
        }
    }
}