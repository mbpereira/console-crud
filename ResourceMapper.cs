using ConsoleCrud.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCrud
{
	public class ResourceMapper : IResourceMapper
	{
		private readonly IResourceWrapper _resourceWrapper;
		public ResourceMapper()
		{
			_resourceWrapper = new ResourceWrapper();
			CreateResources();
		}

		private void CreateResources()
		{
			_resourceWrapper.AddResource("Customer", new CustomerController());
		}

		public IResourceWrapper GetMappedResources()
		{
			return _resourceWrapper;
		}
	}
}
