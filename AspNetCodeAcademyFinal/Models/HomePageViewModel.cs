using DAL.Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCodeAcademyFinal.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<AdvertisementViewModel> AdvertisementViewModels { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}
