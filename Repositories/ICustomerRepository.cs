using ConsoleCrud.Models;
using System.Collections.Generic;

namespace ConsoleCrud.Repositories
{
	public interface ICustomerRepository
	{
		Customer FindCustomerById(int id);
		ICollection<Customer> GetAllCustomers();
		void AddCustomer(Customer customer);
		void DeleteCustomerById(int id);
		void UpdateCustomer(int id, Customer customer);
	}
}