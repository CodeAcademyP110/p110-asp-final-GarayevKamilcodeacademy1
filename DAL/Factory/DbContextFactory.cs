
using DAL.DataAcces.SqlServer;
using DAL.Domian.Abstract;
using System.Threading.Tasks;

namespace DAL.Factory
{
    public  class DbContextFactory
    {
        public static Task<SqlUnitOfWork> CreateSqlDatabaseAsync(string connstring)
        {
            return Task.Run(() =>
            {
                return new SqlUnitOfWork(connstring);
            });
        }
    }
}
