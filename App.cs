using System;

namespace ConsoleCrud
{
	public class App
	{
		private readonly IResourceMapper _resourceMapper;

		public App()
		{
			_resourceMapper = new ResourceMapper();
		}

		public void Start()
		{
			var resources = _resourceMapper.GetMappedResources().ShowAvailableResources();

			Console.WriteLine("Recursos Disponíveis: ");
			Console.WriteLine(string.Join(", ", resources));

			Console.Write("Digite o recurso desejado: ");
			var choosedResource = Console.ReadLine().Trim().ToLower();

			RunResource(choosedResource);
		}

		public void RunResource(string resourceName)
		{
			_resourceMapper
				.GetMappedResources()
				.GetResource(resourceName)
				.Run();
		}
	}
}
