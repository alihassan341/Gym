using Gym_Management_System.Entities;

namespace Gym_Management_System.Repositories
{
    public interface IAdminRepository
    {
        public IList<Admin> GetById(long Id);
        public IList<Admin> GetAll();
        public void Create(Admin Users);
        public void Update(Admin Users);
        public void Delete(long Id);
        public void Save();
    }
}
