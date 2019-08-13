using AspNetCodeAcademyFinal.Models;
using DAL.Domian.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCodeAcademyFinal.Controllers
{
    public class AdvertisementController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AdvertisementModel model = new AdvertisementModel
            {
                Brands = await DB.BrandRepository.Get(),
                Models  = await DB.ModelRepository.Get(),
                Cities = await DB.CityRepository.Get(),
                Colors = await DB.ColorRepository.Get()
            };

            return View(model);
        
        }
        [HttpPost]
        public IActionResult Create(AdvertisementModel model)
        {
            Advertisement advertisement = new Advertisement
            {
               
                City = model.AdvertisementViewModel.City,
                Car = model.AdvertisementViewModel.Car,
                CreationDate = DateTime.Now,
                VIP = false
            };

           advertisement.Car.ID =  DB.CarRepository.AddAndCommit(advertisement.Car);
            
            DB.AdvertisementRepository.Add(advertisement);
            DB.SaveChanges();
         
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int id)
        {
           var data =  DB.AdvertisementRepository.Get(id);
            AdvertisementViewModel advertisementViewModel = new AdvertisementViewModel
            {
                ID = data.ID,
                CreationDate = data.CreationDate,
                City = data.City,
                Car = data.Car,
                PhotoDirectory = data.PhotoDirectory,
                VIP = data.VIP
            };
            return View(advertisementViewModel);
        }
        public IActionResult CreateVIP(AdvertisementModel model)
        {
            Advertisement advertisement = new Advertisement
            {
                City = model.AdvertisementViewModel.City,
                Car = model.AdvertisementViewModel.Car,
                CreationDate = DateTime.Now,
                VIP = true
            };
            advertisement.Car.ID = DB.CarRepository.AddAndCommit(advertisement.Car);

            DB.AdvertisementRepository.Add(advertisement);
            DB.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
