using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.DataAcces.SqlServer;
using DAL.Domian.Abstract;
using DAL.Domian.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCodeAcademyFinal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "AspNetFinalCodeAcademy";
            builder.UserID = "MS";
            builder.Password = "12102000";
            builder.MultipleActiveResultSets = true;
  
            DB = new SqlUnitOfWork(builder.ConnectionString);           
            CreateWebHostBuilder(args).Build().Run();

            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        public static IUnitOfWork DB { get; private set; }
        public static SqlConnectionStringBuilder builder;


    }




}
