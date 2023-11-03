using Gym_Management_System.Data;
using Gym_Management_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gym_Management_System.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private Context _context;
        public AdminRepository(Context context)
        {
            this._context = context;
        }

        public void Create(Admin admin)
        {
            _context.Admins.Add(admin);
        }

        public void Delete(long Id)
        {
            var admin = _context.Admins.Find(Id);            
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }
        }

        public IList<Admin> GetAll()
        {
            return _context.Admins.ToList();
        }
        
        public IList<Admin> GetById(long Id)
        {
            IList<Admin> ReturnAdmin = _context.Admins.Where(u => u.Id == Id).AsNoTracking().ToList();
            return ReturnAdmin;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Admin admin)
        {
            _context.Admins.Update(admin);
        }
    }
}
