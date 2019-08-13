using DAL.Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCodeAcademyFinal.Models
{
    public class AdvertisementModel
    {
      public AdvertisementViewModel AdvertisementViewModel { get; set; }
      public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Color> Colors { get; set; }
    }
}
