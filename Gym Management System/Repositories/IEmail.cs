using Gym_Management_System.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Management_System.Repositories
{
    public interface IEmail
    {
        void EmailSander(Email Request);
    }
}
