using Microsoft.Extensions.Configuration;
using System.IO;
namespace crud
{
    public class Env
    {
        private static Env _instance = null;
        private IConfigurationRoot _configuration;

        public static Env Instance {
            get {
                if(_instance == null)
                    _instance = new Env();
                return _instance;
            }
        }

        private Env() {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("env.json")
                .Build();
        }

        public string Get(string key) {
            return _configuration[key];
        }

    }
}