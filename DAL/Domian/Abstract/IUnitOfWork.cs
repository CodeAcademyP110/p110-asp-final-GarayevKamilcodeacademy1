using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domian.Abstract
{
    public interface IUnitOfWork
    {
        IAdvertisementRepository AdvertisementRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICarRepository CarRepository { get; }
        ICityRepository CityRepository { get; }
        IColorRepository ColorRepository { get; }
        IModelRepository ModelRepository { get; }
        INewsRepository NewsRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }


        void EraseDatabase();
        void SaveChanges();
        void ResetQueue();
        void CheckConnection(string connString);
    }
}
