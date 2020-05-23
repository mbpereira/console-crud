using ConsoleCrud.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCrud
{
	public class ResourceWrapper : IResourceWrapper
	{
		private readonly Dictionary<string, IController> _resourceList;

		public ResourceWrapper()
		{
			_resourceList = new Dictionary<string, IController>();
		}

		public void AddResource(string resourceName, IController resource)
		{
			_resourceList.Add(resourceName.Trim().ToLower(), resource);
		}

		public ICollection<string> ShowAvailableResources()
		{
			return _resourceList.Keys;
		}

		public IController GetResource(string resourceName)
		{
			return _resourceList[resourceName];
		}
	}
}
