using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domian.Entities
{
    public class Advertisement
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
