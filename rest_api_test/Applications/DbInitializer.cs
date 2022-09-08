using Microsoft.EntityFrameworkCore;

namespace rest_api_test.Applications
{
    public class DbInitializer
    {
        public static void Initialize()
        {
            using (var _context = new rest_api_test_db(AppGlobal.GetDBOption()))
            {
                //run primary migration method
                _context.Database.Migrate();
            }
        }
    }
}
