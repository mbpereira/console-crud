using System;
using ConsoleCrud.Models;
using ConsoleCrud.Repositories;
using ConsoleCrud.Factories;

namespace ConsoleCrud
{
    class Program
    {
        static void Main(string[] args)
        {
			var app = new App();
			app.Start();
        }       
    }
}
