using Gym_Management_System.Data;
using Gym_Management_System.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gym_Management_System.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Context _context;        
        public UserRepository(Context context)
        {
            this._context = context;            
        }

        public void Create(User Users)
        {
            _context.Users.Add(Users);            
        }

        public void Delete(long Id)
        {
            var User = _context.Users.Find(Id);
            if (User != null)
            {
                _context.Users.Remove(User);
            }            
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public IList<User> GetById(long Id)
        {
             IList<User> ReturnUser  = _context.Users.Where(u => u.Id == Id).AsNoTracking().ToList();
            return ReturnUser;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User Users)
        {
            _context.Users.Update(Users);            
        }
    }
}
