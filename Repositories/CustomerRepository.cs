using System.Collections.Generic;
using ConsoleCrud.Infrastructure.Mappers;
using ConsoleCrud.Models;

namespace ConsoleCrud.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly ICustomerMapper _customerMapper;
		public CustomerRepository(ICustomerMapper customerMapper)
		{
			_customerMapper = customerMapper;
		}
		public void AddCustomer(Customer customer)
		{
			_customerMapper.Save(customer);
		}

		public void DeleteCustomerById(int id)
		{
			_customerMapper.Delete(id);
		}

		public Customer FindCustomerById(int id)
		{
			return _customerMapper.FindByInd(id);
		}

		public ICollection<Customer> GetAllCustomers()
		{
			return _customerMapper.All();
		}

		public void UpdateCustomer(int id, Customer customer)
		{
			_customerMapper.Update(id, customer);
		}
	}
}
