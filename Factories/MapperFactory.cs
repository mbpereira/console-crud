using ConsoleCrud.Infrastructure;
using ConsoleCrud.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCrud.Factories
{
	public class MapperFactory
	{
		private static MapperFactory _mapperFactory;
		private DatabaseConnection _databaseConnection;

		private MapperFactory() {
			_databaseConnection = new SqlServerConnection();
		}

		public static MapperFactory CreateFactory()
		{
			if(_mapperFactory == null)
			{
				_mapperFactory = new MapperFactory();
			}

			return _mapperFactory;
		}

		public ICustomerMapper GetCustomerMapper()
		{
			return new CustomerMapper(_databaseConnection);
		} 
	}
}
