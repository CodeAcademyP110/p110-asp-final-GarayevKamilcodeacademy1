using DAL.Domian.Abstract;
using DAL.Domian.Entities;
using System;
using System.Collections.Generic;

namespace DAL
{
    public static class Kernel
    {
        public static IUnitOfWork DB { get; set; } = null;
    }
}
