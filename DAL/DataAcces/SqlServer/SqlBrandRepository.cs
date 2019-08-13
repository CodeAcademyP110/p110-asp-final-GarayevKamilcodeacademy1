using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL.Domian.Abstract;
using DAL.Domian.Entities;
using DAL.HelpersAndExtensions;

namespace DAL.DataAcces.SqlServer
{
    public class SqlBrandRepository : IBrandRepository
    {
        private SqlContext db;
        public SqlBrandRepository(SqlContext db)
        {
            this.db = db;
        }
        public void Add(Brand obj)
        {
            throw new System.NotImplementedException();
        }

        public Brand Get(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                 
                string query = "Select * from Brands where ID = @ID";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        return GetFromReader(reader);
                    }
                    return null;
                }
            }
        }

        public Brand Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Brand>> Get()
        {
            return Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    con.Open();
                    List<Brand> brands = new List<Brand>();
                    string query = @"Select * from Brands";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            brands.Add(GetFromReader(reader));
                        }
                    }
                    return brands.AsEnumerable();
                }
            });
            
        }
        
        private Brand GetFromReader(SqlDataReader reader)
        {
            Brand brand = new Brand
            {
                ID =  reader.GetInt32("ID"),
                Name = reader.GetString("Name")
            };
            return brand;
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
