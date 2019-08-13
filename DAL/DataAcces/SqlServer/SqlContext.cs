using DAL.Domian.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.DataAcces.SqlServer
{
    public class SqlContext
    {
        SqlUnitOfWork db { get; set; }
        public SqlContext(SqlUnitOfWork db)
        {
            this.db = db;
            ConnectionString = db.ConnectionString;
            UnitOfWork = db;
        }
        public string ConnectionString { get; private set; }
        public void AddCommandToTransaction(SqlCommand cmd) => db.AddCommandToQueue(cmd);

        public IUnitOfWork UnitOfWork { get; private set; }
    }
}
