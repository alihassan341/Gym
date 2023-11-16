using Gym_Management_System.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Gym_Management_System.Data
{
    public class Context : IdentityDbContext<IdentityUser>// DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        {
        
        }




        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Equipment> Equipments{ get; set; }
        public DbSet<Email> Emails { get; set; }
        //public DbSet<Login> Logins { get; set; }
        //public DbSet<Register> Registers { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
    }

}
