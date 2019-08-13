﻿using DAL.Domian.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domian.Abstract
{
    public interface ICarRepository : IRepository<Car>
    {
         int AddAndCommit(Car obj);
    }
}
