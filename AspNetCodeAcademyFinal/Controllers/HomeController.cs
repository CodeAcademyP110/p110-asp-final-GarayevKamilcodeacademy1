using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCodeAcademyFinal.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCodeAcademyFinal.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {    
     
        public async Task<IActionResult> Index()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
           
            var data = await DB.AdvertisementRepository.Get();
            var NewsData = await DB.NewsRepository.Get();
            List<AdvertisementViewModel> advertisementViewModels = new List<AdvertisementViewModel>();
            foreach (var item in data)
            {
                AdvertisementViewModel model = new AdvertisementViewModel
                {
                    ID = item.ID,
                    CreationDate = item.CreationDate,
                    RefreshDate =item.RefreshDate,
                    City = item.City,
                    Car = item.Car,
                    VIP = item.VIP,
                    PhotoDirectory =  item.PhotoDirectory
                };
                advertisementViewModels.Add(model);
            }
            homePageViewModel.AdvertisementViewModels = advertisementViewModels;            
            homePageViewModel.News = NewsData.Take(5).OrderBy(x => x.CreationDate);
            return View(homePageViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
