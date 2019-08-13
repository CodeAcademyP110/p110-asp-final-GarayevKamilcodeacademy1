using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DAL.Domian.Abstract;
using DAL.Domian.Entities;
using DAL.HelpersAndExtensions;

namespace DAL.DataAcces.SqlServer
{
    public class SqlRoleRepository : IRoleRepository
    {
        SqlContext db;
        public SqlRoleRepository(SqlContext db)
        {
            this.db = db;
        }
        public void Add(Role obj)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = null;
                con.Open();
                if(obj.ID == 0 )
                {
                    query = "Insert into Roles values(@Name,@NormalizedName)";
                }
                else
                {
                    query = "update Roles set Name = @Name,NormalizedName = @NormalizedName where Id = @Id";
                }
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    if (obj.ID != 0) cmd.Parameters.AddWithValue("@Id", obj.ID);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@NormalizedName", obj.NormalizedName);
                    db.AddCommandToTransaction(cmd);
                }
            }
        }

        public Role Get(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = "Select * from Roles where Id = @Id";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        return GetFromReader(reader);
                    }
                    return null;
                }
            }
        }

        public Role Get(string name)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = "Select * from Roles where Name = @Name";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return GetFromReader(reader);
                }
            }
        }

        public Task<IEnumerable<Role>> Get()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
        private Role GetFromReader(SqlDataReader reader)
        {
            Role role = new Role
            {
                ID = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),               
            };
            return role;
        }
    }
}
