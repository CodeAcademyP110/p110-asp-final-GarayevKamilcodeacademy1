using DAL.Domian.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCodeAcademyFinal.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork DB { get => Program.DB; }
    }
}
