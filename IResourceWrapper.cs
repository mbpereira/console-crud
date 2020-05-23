using System.Collections.Generic;
using ConsoleCrud.Controllers;

namespace ConsoleCrud
{
	public interface IResourceWrapper
	{
		void AddResource(string resourceName, IController resource);
		IController GetResource(string resourceName);
		ICollection<string> ShowAvailableResources();
	}
}