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
    public class SqlNewsRepository : INewsRepository
    {
        SqlContext db;
        public SqlNewsRepository(SqlContext db)
        {
            this.db = db;
        }
        public void Add(News obj)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = null;
                con.Open();
                if(obj.ID == 0 )
                {
                    query = @"Insert into News values(@CreationDate,@PhotoDirectory,@Title,@TextDirectory)";
                }
                else
                {
                    query = @"Update News set CreationDate = @CreationDate,PhotoDirectory = @PhotoDirectory
,Title= @Title,TextDirectory = @TextDirectory where ID = @ID";
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (obj.ID != 0) cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@CreationDate", obj.CreationDate);
                    cmd.Parameters.AddWithValue("@PhotoDirectory", obj.PhotoDirectory);
                    cmd.Parameters.AddWithValue("Title", obj.Title);
                    cmd.Parameters.AddWithValue("TextDirectory", obj.TextDirectory);
                }
            }
        }

        public News Get(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = "Select * from News where ID= @ID";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return GetFromReader(reader);
                }
            }
        }

        public News Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<News>> Get()
        {
            return Task.Run(() =>
            {
               using (SqlConnection con = new SqlConnection(db.ConnectionString))
               {
                   string query = "Select * from News";
                    List<News> newss = new List<News>();
                   con.Open();
                   using (SqlCommand cmd = new SqlCommand(query, con))
                   {
                       SqlDataReader reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            newss.Add(GetFromReader(reader));
                        }
                        return newss.AsEnumerable();
                   }
               }
            });
            
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        private News GetFromReader(SqlDataReader reader)
        {
            News news = new News
            {
                ID = reader.GetInt32("ID"),
                CreationDate = reader.GetDateTime("CreationDate"),
                PhotoDirectory = reader.GetString("PhotoDirectory"),
                Title = reader.GetString("Title"),
                TextDirectory = reader.GetString("TextDirectory")
            };
            return news;
        }
    }
}
