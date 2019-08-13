using DAL.Domian.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCodeAcademyFinal.Models
{
    public class AdvertisementViewModel 
    {
            public int ID { get; set; }
            public DateTime CreationDate { get; set; }
            public DateTime? RefreshDate { get; set; }
            public City City { get; set; }
            public Car Car { get; set; }
            public bool VIP { get; set; }
           public string PhotoDirectory { get; set; }
        
    }
}
