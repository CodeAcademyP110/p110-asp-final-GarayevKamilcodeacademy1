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
    public class SqlModelRepository : IModelRepository
    {
        SqlContext db;
        public SqlModelRepository(SqlContext db)
        {
            this.db = db;
        }
        public void Add(Model obj)
        {
            throw new NotImplementedException();
        }

        public Model Get(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                string query = @"select * form Models where ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return GetFromReader(reader);
                }
            }
        }

        public Model Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model>> Get()
        {
            return Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    con.Open();
                    List<Model> models = new List<Model>();
                    using(SqlCommand cmd=  new SqlCommand("Select * from Models",con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            models.Add(GetFromReader(reader));
                        }
                        return models.AsEnumerable();
                    }
                }
            });
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        private Model GetFromReader(SqlDataReader reader)
        {
            Model model = new Model
            {
                ID = reader.GetInt32("ID"),
                Name = reader.GetString("Name"),
                Brand = db.UnitOfWork.BrandRepository.Get(reader.GetInt32("BrandID"))
            };      
            
              return model;
        }
    }
}
