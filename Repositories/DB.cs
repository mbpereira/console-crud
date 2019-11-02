using Npgsql;

namespace crud.Repositories
{
    public class DB
    {
        private static DB _instance = null;
        private NpgsqlConnection _connection; 
        public static DB Instance { 
            get {
                if(_instance == null)
                    _instance = new DB();
                return  _instance;
            }
        }

        public NpgsqlConnection Connection {
            get {
                return _connection;
            }
        }
        private DB () {
            Env env = Env.Instance;
            _connection = new NpgsqlConnection(env.Get("DATABASE_URL"));
        }

    }
}