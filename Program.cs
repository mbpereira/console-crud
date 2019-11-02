using System;
using crud.Models;
using crud.Repositories;

namespace crud
{
    class Program
    {
        static void Main(string[] args)
        {
            char op;
            do {
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
            } while(op != 'e');
        }
        
        static void Choose(char op) {
            switch(op) {
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
        static void Add() {
            string name, email, phone;
            Customer customer = new Customer();
            CustomerRepo customerRepo = new CustomerRepo();
            
            Console.Write("Nome: ");
            name = Console.ReadLine();
            
            Console.Write("Email: ");
            email = Console.ReadLine();

            Console.Write("Phone");
            phone = Console.ReadLine();

            customer.Name = name;
            customer.Email = email;
            customer.Phone = phone;

            customerRepo.Save(customer);



            
        }
        static void Destroy() {
            int id = -1;
            Console.Write("Id: ");
            id = int.Parse(Console.ReadLine());

            CustomerRepo customerRepo = new CustomerRepo();
            customerRepo.Delete(id);
            
        }

        static void Update() {
            string name, email, phone;
            int id;
            Customer customer = new Customer();
            CustomerRepo customerRepo = new CustomerRepo();
            
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

            customerRepo.Update(id, customer);
        }
        static void List() {
            foreach(Customer customer in new CustomerRepo().All()) {
                Console.WriteLine(
                    $"id: {customer.Id}, Nome: {customer.Name}, Email: {customer.Email}, Phone: {customer.Phone}"
                );
            }
        }
    }
}
