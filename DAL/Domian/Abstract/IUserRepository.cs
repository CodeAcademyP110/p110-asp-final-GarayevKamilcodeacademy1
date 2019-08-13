using DAL.Domian.Entities;

using System.Threading;
using System.Threading.Tasks;

namespace DAL.Domian.Abstract
{
    public interface IUserRepository
    {
        void CreateOrEdit(User obj);
        User GetByUsername(string username);
        User GetByEmail(string Email);
    }
}
