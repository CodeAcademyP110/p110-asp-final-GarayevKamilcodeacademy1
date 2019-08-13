using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domian.Entities
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get => Name.Normalize(); }
    }
}
