using Gym_Management_System.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Management_System.Repositories
{
    public interface IUserRepository 
    {
        public IList<User> GetById(long Id);
        public  IList<User> GetAll();
        public  void Create(User Users);
        public void Update(User Users);
        public void Delete(long Id);
        public void Save();
    }
}
