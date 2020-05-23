using ConsoleCrud.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCrud.Factories
{
	public class RepositoryFactory
	{
		public static RepositoryFactory _repositoryFactory;
		private readonly MapperFactory _mapperFactory;
		private RepositoryFactory()
		{
			_mapperFactory = MapperFactory.CreateFactory();
		}

		public static RepositoryFactory CreateFactory()
		{
			if (_repositoryFactory == null)
				_repositoryFactory = new RepositoryFactory();

			return _repositoryFactory;
		}

		public ICustomerRepository GetCustomerRepository()
		{
			return new CustomerRepository(_mapperFactory.GetCustomerMapper());
		}
	}
}
