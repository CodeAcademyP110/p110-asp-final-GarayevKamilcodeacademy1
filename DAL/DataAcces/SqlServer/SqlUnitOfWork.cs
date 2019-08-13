using DAL.Domian.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.LogHelper;
namespace DAL.DataAcces.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        public string ConnectionString { get; private set; }
       
        private Queue<SqlCommand> queuedCommands = new Queue<SqlCommand>();
        private SqlContext context;
        public SqlUnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
            context = new SqlContext(this);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);
        }


        public IAdvertisementRepository AdvertisementRepository => new SqlAdvertisementRepository(context);

        public IBrandRepository BrandRepository =>  new SqlBrandRepository(context);

        public ICarRepository CarRepository =>  new SqlCarRepository(context);

        public ICityRepository CityRepository =>  new SqlCityRepository(context);

        public IColorRepository ColorRepository =>  new SqlColorRepository(context);

        public IModelRepository ModelRepository =>  new SqlModelRepository(context);

        public INewsRepository NewsRepository =>  new SqlNewsRepository(context);

        public IRoleRepository RoleRepository => new SqlRoleRepository(context);

        public IUserRepository UserRepository => new SqlUserRpository(context);

        public void AddCommandToQueue(SqlCommand comm)
        {
            queuedCommands.Enqueue(comm);
        }

        public void SaveChanges()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var tr = conn.BeginTransaction();
                try
                {
                    while (queuedCommands.Count > 0)
                    {
                        var c = queuedCommands.Dequeue();
                        c.Connection = conn;
                        c.Transaction = tr;
                        c.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    queuedCommands = new Queue<SqlCommand>();
                    if (tr != null) tr.Rollback();
                    Logger.WriteTextAsync("Bazaya yazmağa cəhd, XƏTA: " + ex.Message);
                    throw ex;
                }
            }
        }

        public void ResetQueue()
        {
            queuedCommands = new Queue<SqlCommand>();
        }

        public void EraseDatabase()
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Open();
                new SqlCommand("EXEC EraseAllData", cnn).ExecuteNonQuery();
                //Stored Procedure Doesn't created
            }
        }

        public void CheckConnection(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) conn.Open();
        }

    }
}
