using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domian.Abstract
{
    public interface IRepository<T>
    {

        void Add(T obj);
        T Get(int id);
        T Get(string name);
        Task<IEnumerable<T>> Get();
        void Remove(int id);
    }
}
