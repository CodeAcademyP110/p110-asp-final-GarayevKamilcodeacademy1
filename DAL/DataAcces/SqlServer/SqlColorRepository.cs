using DAL.Domian.Abstract;
using DAL.Domian.Entities;
using DAL.HelpersAndExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DataAcces.SqlServer
{
    public class SqlColorRepository : IColorRepository
    {
        private SqlContext db;
        public SqlColorRepository(SqlContext db)
        {
            this.db = db;
        }
        public void Add(Color obj)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = null;
                con.Open();
                if(obj.ID == 0)
                {
                    query = "Insert into Colors values(@Name)";
                }
                else
                {
                    query = "Update Colors set Name= @Name where ID = @ID";
                }
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (obj.ID != 0) cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    db.AddCommandToTransaction(cmd);
                }
            }
        }

        public Color Get(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = @"Select * form Colors where ID= @ID";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return GetfFromReader(reader);
                }
            }
        }

      

        public Color Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Color>> Get()
        {
            return Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    string query = @"Select * from Colors";
                    List<Color> colors = new List<Color>();
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            colors.Add(GetfFromReader(reader));
                        }
                        return colors.AsEnumerable();
                    }
                }
            });
          
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        private Color GetfFromReader(SqlDataReader reader)
        {
            Color color = new Color
            {
                ID = reader.GetInt32("ID"),
                Name = reader.GetString("Name")
            };
            return color;
        } 
    }
}
