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
    public class SqlCarRepository : ICarRepository
    {
        SqlContext db;

        public SqlCarRepository(SqlContext db)
        {
            this.db = db;
        }
        public void Add(Car obj)
        {
            throw new NotImplementedException();
        }
        public int AddAndCommit(Car obj)
        {
           
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                string query = null;
                string Photoquery = null;
                int CarID = 0;
                var tr = con.BeginTransaction();
                if (obj.ID == 0)
                {
                    query = @"insert into Cars
                         values(
                         @Name, @Price, @ModelID, @EngineCapacity, @ColorID, @Mileage, @FuelType, @Transmission, @About,@Year); SELECT CAST(SCOPE_IDENTITY() as int)";
                    Photoquery = @"Insert into Photos
                                   values(@PhotoDirectory,@CarID)";
                }
                else
                {
                    query = @"update Cars set Name = @Name,Price = @Price,ModelID = @ModelID,EngineCapacity = @EngineCapacity,ColorID = @ColorID,
                      Mileage = @Mileage,FuelType = @FuelType,Transmission = @Transmission,About = @About where ID = @ID";
                    Photoquery = @"update Photos set PhotoDirectory = @PhotoDirectory,
                                     CarID = @CarID where ID = @ID";
                }

                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Transaction = tr;

                    if (obj.ID != 0) cmd.Parameters.AddWithValue("@ID", obj.ID);

                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Price", obj.Price);
                    cmd.Parameters.AddWithValue("@ModelID", obj.Model.ID);
                    cmd.Parameters.AddWithValue("@EngineCapacity", obj.EngineCapacity);
                    cmd.Parameters.AddWithValue("@ColorID", obj.Color.ID);
                    cmd.Parameters.AddWithValue("@Mileage", obj.Mileage );
                    cmd.Parameters.AddWithValue("@FuelType", obj.FuelType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Transmission", obj.Transmission ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@About", obj.About ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Year", obj.Year);
                    CarID = (int)cmd.ExecuteScalar();
                   
                }

                if(obj.Photos !=null)
                {
                    foreach (var item in obj.Photos)
                    {
                        using (SqlCommand cmd = new SqlCommand(Photoquery, con))
                        {
                            if (item.ID != 0) cmd.Parameters.AddWithValue("@ID", item.ID);
                            cmd.Parameters.AddWithValue("@PhotoDirectory", item.Directory);
                            cmd.Parameters.AddWithValue("@CarID", item.CarID);
                           
                            cmd.Transaction = tr;
                            cmd.BeginExecuteNonQuery();
                        }
                    }
                   
                }

                tr.Commit();
                return CarID;
            }
        }
       
        
        public Car Get(int id)
        {
         

            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                string query = @"select c.*,m.Name as ModelName,b.ID as BrandID,b.Name as BrandName,color.Name as ColorName
from Cars as c
left join Models as m on c.ModelID	 =  m.ID
left join Brands as b on m.BrandID = b.ID
left join Colors as color  on  c.ColorID =  color.ID
where c.ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query,con))
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

       
        public Car Get(string name)
        {
           
           using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                string query = @"select c.*,m.Name as ModelName,b.ID as BrandID,b.Name as BrandName,color.Name as ColorName
from Cars as c
left join Models as m on c.ModelID	 =  m.ID
left join Brands as b on m.BrandID = b.ID
left join Colors as color  on  c.ColorID =  color.ID
where c.Name = @Name";
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

        public Task<IEnumerable<Car>> Get()
        {
            return Task.Run(() =>
           {
               using (SqlConnection con = new SqlConnection(db.ConnectionString))
               {
                   List<Car> cars = new List<Car>();
                   con.Open();
                   string query = @"select c.*,m.Name as ModelName,b.ID as BrandID,b.Name as BrandName,color.Name as ColorName
from Cars as c
left join Models as m on c.ModelID	 =  m.ID
left join Brands as b on m.BrandID = b.ID
left join Colors as color  on  c.ColorID =  color.ID";
                   using (SqlCommand cmd = new SqlCommand(query, con))
                   {
                       SqlDataReader reader = cmd.ExecuteReader();
                       while (reader.Read())
                       {
                           cars.Add(GetFromReader(reader));
                       }

                   }
                   return cars.AsEnumerable();
               }
           });
           
        }

        public void Remove(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Delete * from cars where ID = @id"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        private Car GetFromReader(SqlDataReader reader)
        {

            Car car = new Car
            {
                ID = reader.GetInt32("ID"),
                Price = reader.GetDecimal("Price"),
                EngineCapacity = reader.GetInt32("EngineCapacity"),
                Mileage = reader.GetDecimal("Mileage"),
                FuelType = reader.GetString("FuelType"),
                Transmission = reader.GetString("Transmission"),
                Year = reader.GetInt32("Year"),
                Model = new Model
                {
                    ID = reader.GetInt32("ModelID"),
                    Name = reader.GetString("ModelName"),
                    Brand = new Brand
                    {
                        ID = reader.GetInt32("BrandID"),
                        Name = reader.GetString("BrandName"),
                    }
                },
                Color = new Color
                {
                    ID = reader.GetInt32("ColorID"),
                    Name = reader.GetString("ColorName")
                }
            };
            using(SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand photoCmd = new SqlCommand("Select * from photos where ID = @ID ", con))
                {
                    List<Photo> photos = new List<Photo>();
                    photoCmd.Parameters.AddWithValue("@ID", car.ID);
                    SqlDataReader photoReader = photoCmd.ExecuteReader();
                    while (photoReader.Read())
                    {
                        Photo photo = new Photo
                        {
                            ID = photoReader.GetInt32("ID"),
                            Directory = photoReader.GetString("PhotoDirectory")
                        };
                        photos.Add(photo);
                    }
                    car.Photos = photos;
                }

            }

            return car;
        }

    }
}
