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
    public class SqlAdvertisementRepository : IAdvertisementRepository
    {
        private SqlContext db;
        public SqlAdvertisementRepository(SqlContext db)
        {
            this.db = db;
        }
        public void Add(Advertisement obj)
        {
       
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = null;
                con.Open();
                if(obj.ID == 0)
                {
                    query = @"Insert into Advertisements 
values(@CreationDate,@RefreshDate,@CityID,@CarID,@VIP,@PhotoDirectory)";
                }else
                {
                    query = @"update Advertisements set CreationDate =@CreationDate,RefreshDate = @RefreshDate,CityID = @CityID,CarID = @CarID,VIP = @VIP
where ID = @ID";
                }
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (obj.ID != 0) cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@CreationDate", obj.CreationDate);
                    cmd.Parameters.AddWithValue("@RefreshDate", obj.RefreshDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CityID", obj.City.ID);
                    cmd.Parameters.AddWithValue("@CarID", obj.Car.ID);
                    cmd.Parameters.AddWithValue("@VIP", obj.VIP);
                    cmd.Parameters.AddWithValue("@PhotoDirectory", obj.PhotoDirectory ?? (object)DBNull.Value);
                    db.AddCommandToTransaction(cmd);
                }
            }
        }

        public Advertisement Get(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = "Select * from Advertisements where ID = @ID";
                con.Open();
                using(SqlCommand cmd =  new SqlCommand(query,con))
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
 
        public Advertisement Get(string name)
        {
            throw new NotImplementedException();
        }

        public  Task<IEnumerable<Advertisement>> Get()
        {
            return Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    string query = "select * from Advertisements";
                    try
                    {
                        con.Open();
                    }
                    catch(Exception ex) { string message = ex.Message; }
                    List<Advertisement> advertisements = new List<Advertisement>();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            advertisements.Add(GetFromReader(reader));
                        }
                        return advertisements.AsEnumerable();
                    }
                }
            });
         
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        private Advertisement GetFromReader(SqlDataReader reader)
        {
            Advertisement advertisement = new Advertisement
            {
                ID = reader.GetInt32("ID"),
                CreationDate =  reader.GetDateTime("CreationDate"),
                RefreshDate =  reader.GetDateTimeOrNull("RefreshDate"),
                VIP =  reader.GetBoolean("VIP"),
                PhotoDirectory = reader.GetString("PhotoDirectory"),
                City = db.UnitOfWork.CityRepository.Get(reader.GetInt32("CityID")),
                Car =  db.UnitOfWork.CarRepository.Get(reader.GetInt32("CarID"))
            };

            return advertisement;
        }
    }
}
