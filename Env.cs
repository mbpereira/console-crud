using Microsoft.Extensions.Configuration;
using System.IO;
namespace ConsoleCrud
{
    public class Env
    {
        private static Env _instance = null;
        private IConfigurationRoot _configuration;

        private Env() {
			string projectPath =
				Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			_configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

		public static Env GetInstance()
		{
			if (_instance == null)
				_instance = new Env();
			return _instance;
		}

        public string Get(string key) {
            return _configuration[key];
        }

    }
}