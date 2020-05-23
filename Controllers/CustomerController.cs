using ConsoleCrud.Factories;
using ConsoleCrud.Models;
using ConsoleCrud.Repositories;
using System;

namespace ConsoleCrud.Controllers
{
	public class CustomerController : IController
	{
		private readonly ICustomerRepository _customerRepo;
		public CustomerController()
		{
			_customerRepo = RepositoryFactory.CreateFactory().GetCustomerRepository();
		}

		public void Add()
		{
			string name, email, phone;
			Customer customer = new Customer();

			Console.Write("Nome: ");
			name = Console.ReadLine();

			Console.Write("Email: ");
			email = Console.ReadLine();

			Console.Write("Phone: ");
			phone = Console.ReadLine();

			customer.Name = name;
			customer.Email = email;
			customer.Phone = phone;

			_customerRepo.AddCustomer(customer);
		}

		public void Destroy()
		{
			int id;
			Console.Write("Id: ");
			id = int.Parse(Console.ReadLine());

			_customerRepo.DeleteCustomerById(id);
		}

		public void Update()
		{
			string name, email, phone;
			int id;
			Customer customer = new Customer();

			Console.Write("Id: ");
			id = int.Parse(Console.ReadLine());
			Console.Write("Novo Nome: ");
			name = Console.ReadLine();

			Console.Write("Novo Email: ");
			email = Console.ReadLine();

			Console.Write("Novo Phone: ");
			phone = Console.ReadLine();

			customer.Name = name;
			customer.Email = email;
			customer.Phone = phone;

			_customerRepo.UpdateCustomer(id, customer);
		}
		public void List()
		{
			foreach (Customer customer in _customerRepo.GetAllCustomers())
			{
				Console.WriteLine(
					$"id: {customer.Id}, Nome: {customer.Name}, Email: {customer.Email}, Phone: {customer.Phone}"
				);
			}
		}

		public void Run()
		{
			char op;
			do
			{
				Console.WriteLine("Simple Crud");
				Console.WriteLine(@"
                    a - Add Record
                    d - Destroy Record
                    u - Update Record
                    l - List all Records
                    e - Exit
                ");
				op = Console.ReadLine()[0];

				Choose(op);
			} while (op != 'e');
		}

		private void Choose(char op)
		{
			switch (op)
			{
				case 'a':
					Add();
					break;
				case 'd':
					Destroy();
					break;
				case 'u':
					Update();
					break;
				case 'l':
					List();
					break;
			}
		}
	}
}
