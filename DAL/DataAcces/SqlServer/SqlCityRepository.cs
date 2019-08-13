using DAL.Domian.Abstract;
using DAL.Domian.Entities;
using DAL.HelpersAndExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAcces.SqlServer
{
    public class SqlCityRepository : ICityRepository
    {
        private SqlContext db;
        public SqlCityRepository(SqlContext db)
        {
            this.db = db;
        }
        public void Add(City obj)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = null;
                con.Open();
                if(obj.ID == 0)
                {
                    query = "Insert into Cities values(@Name)";
                }
                else
                {
                    query = "Update Cities set Name = @Name where ID = @ID";
                }
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (obj.ID != 0) cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                }
            }
        }

        public City Get(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = @"Select * from Cities where ID = @ID";
                con.Open();
                using(SqlCommand  cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return GetFromReader(reader);
                    }
                        return null;
                    
                }
            }
        }

        public City Get(string name)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = @"Select * from Cities where Name = @Name";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return GetFromReader(reader);
                    }
                    return null;
                }
            }
        }

        
        public Task<IEnumerable<City>> Get()
        {
            return Task.Run(() => {
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    string query = @"select * from Cities";
                    List<City> cities = new List<City>();
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            cities.Add(GetFromReader(reader));
                        }
                    }
                    return cities.AsEnumerable();
                }
            });
           
          
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        private City GetFromReader(SqlDataReader reader )
        {
            City city = new City
            {
                ID = reader.GetInt32("ID"),
                Name = reader.GetString("Name")
            };
            return city;
        }
    }
}
