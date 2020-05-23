using System.Collections.Generic;
using ConsoleCrud.Models;

namespace ConsoleCrud.Infrastructure.Mappers
{
	public interface ICustomerMapper
	{
		List<Customer> All();
		bool Delete(int id);
		Customer FindByInd(int id);
		bool Save(Customer customer);
		bool Update(int id, Customer customer);
	}
}