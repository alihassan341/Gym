using Gym_Management_System.Entities;
using Gym_Management_System.Entities.Auth;
using Gym_Management_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym_Management_System.Controllers
{
    [Authorize(Roles = UserRoles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(UserRepository userrepository)
        {
            _userRepository = userrepository;
        }
      
        [HttpPost("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<User>> Create(User user)
        {
            if (ModelState.IsValid)
            {
                 _userRepository.Create(user);
                _userRepository.Save();
            }
            else
            {
                return BadRequest(ModelState);
            }
            return Ok(this.GetAll());
        }

        [HttpPut("Update")]        
        public async Task<ActionResult<User>> Put(User user)
        {
            if (ModelState.IsValid)
            {
                 _userRepository.Update(user);
                _userRepository.Save();                
            }
            else
            {
                return BadRequest(ModelState);

            }
            return Ok(this.GetAll());
        }


        [HttpGet("GetAll")]
        public  IList<User> GetAll()
        {
          return  _userRepository.GetAll();
        }


        [HttpGet("GetById")]
        public IList<User> GetById(long Id)
        {
            return _userRepository.GetById(Id);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long Id)
        {
             _userRepository.Delete(Id);
            _userRepository.Save();
            return Ok("Deleted Successfully");
        }

    }
}
