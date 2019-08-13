using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DAL.Domian.Abstract;
using DAL.Domian.Entities;
using DAL.HelpersAndExtensions;

namespace DAL.DataAcces.SqlServer
{
    public class SqlUserRpository : IUserRepository
    {
        SqlContext db;
        public SqlUserRpository(SqlContext db)
        {
            this.db = db;
        }

        public void CreateOrEdit(User obj)
        {
            throw new System.NotImplementedException();
        }

        public void CreateOrEditUser(User obj)
        {
            using (SqlConnection con = new  SqlConnection(db.ConnectionString))
            {
                string query = null;
                con.Open();
                if (obj.ID == 0)
                {
                   query =  @"insert into Users values(@Id,@RoleID,@UserName,@NormalizedUserName,@Email,@EmailConfirmed,@Password,@PasswordHash,@PhoneNumber,
@PhoneNumberConfirmed,@TwoFactorEnabled)";
                }
                else
                {
                    query = @"Update Users set UserName = @UserName,NormalizedUserName= @NormalizedUserName,Email= @Email,EmailConfirmed=@EmailConfirmed,
Password = @Password,PasswordHash = @PasswordHash,PhoneNumber= @PhoneNumber,@PhoneNumberConfirmed = PhoneNumberConfirmed,TwoFactorEnabled = @TwoFactorEnabled where Id = @Id";
                }
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    if (obj.ID != 0) cmd.Parameters.AddWithValue("Id", obj.ID);
                    cmd.Parameters.AddWithValue("@UserName", obj.UserName);
                    cmd.Parameters.AddWithValue("@NormalizedUserName", obj.NormalizedUserName);
                    cmd.Parameters.AddWithValue("@Email", obj.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmailConfirmed", obj.EmailConfirmed );
                    cmd.Parameters.AddWithValue("@Password", obj.Password ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("PasswordHash", obj.PasswordHash ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNUmber", obj.PhoneNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumberConfirmed", obj.PhoneNumberConfirmed);
                    cmd.Parameters.AddWithValue("@TwoFactorEnabled", obj.TwoFactorEnabled);
                    db.AddCommandToTransaction(cmd);
                }
            }
        }

        public User GetByEmail(string Email)
        {
            using(SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();

                string query = @"Select * from Users where NormalizedEmail = @NormalizedEmail";
                using(SqlCommand cmd = new SqlCommand(query,con))
                {
                    
                    cmd.Parameters.AddWithValue("@NormalizedEmail", Email.Normalize());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        return GetFromReader(reader);
                    }
                    return null;
                }
            }
        }

        public User GetByUsername(string username)
        {
            throw new System.NotImplementedException();
        }


        public User GetFromReader(SqlDataReader reader)
        {
            User user = new User
            { 
                ID = reader.GetInt32("Id"),
                UserName = reader.GetString("UserName"),
                Email = reader.GetString("Email"),
                Password = reader.GetString("Password"),
                PhoneNumber = reader.GetString("PhoneNumber"),
                Role = db.UnitOfWork.RoleRepository.Get(reader.GetInt32("RoleID"))
            };
            return user;
        }
    }
}
