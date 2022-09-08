using Microsoft.EntityFrameworkCore;

namespace rest_api_test.Applications
{
    public class AppGlobal
    {
        internal static string BASE_URL = "";
        internal static string MYSQL_CS = "Server=127.0.0.1;Port=50000;Database=rest_api_test;Uid=root;Pwd=Freedom223";

        static internal string GetConnectionString(string db_server = "MySQL")
        {
            string connection = "";
            if (db_server == "MySQL")
            {
                connection = MYSQL_CS;
            }
            return connection;
        }

        public static string GetWorkingdirectory()
        {
            return BASE_URL;
        }

        public static dynamic GetDBOption()
        {
            DbContextOptionsBuilder ob = new DbContextOptionsBuilder<rest_api_test_db>();
            ob.UseMySql(GetConnectionString(), new MySqlServerVersion(new Version()));
            return ob.Options;
        }
    }
}
