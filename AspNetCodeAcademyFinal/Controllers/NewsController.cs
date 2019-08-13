using DAL.Domian.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCodeAcademyFinal.Controllers
{
    
    public class NewsController : BaseController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Create(News news)
        {
            DB.SaveChanges();
            return Redirect("/");
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Details(int id)
        {
            var data = DB.NewsRepository.Get(id);
            return View(data);
        }
    }
}
