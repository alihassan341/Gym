using Gym_Management_System.Entities;
using Gym_Management_System.Entities.Auth;
using Gym_Management_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Gym_Management_System.Controllers
{
    [Authorize(Roles = UserRoles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private IEquipmentRepository _equipmentRepository;
        public EquipmentController(EquipmentRepository equipmentRepository)
        {
            this._equipmentRepository = equipmentRepository;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Equipment>> Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _equipmentRepository.Create(equipment);
                _equipmentRepository.Save();
            }
            else
            {
                return BadRequest(ModelState);
            }
            return Ok(this.GetAll());
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Equipment>> Put(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _equipmentRepository.Update(equipment);
                _equipmentRepository.Save();
            }
            else
            {
                return BadRequest(ModelState);

            }
            return Ok(this.GetAll());
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet("GetAll")]
        public IList<Equipment> GetAll()
        {
            return _equipmentRepository.GetAll();
        }


        [HttpGet("GetById")]
        public IList<Equipment> GetById(long Id)
        {
            return _equipmentRepository.GetById(Id);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long Id)
        {
            _equipmentRepository.Delete(Id);
            _equipmentRepository.Save();
            return Ok("Deleted Successfully");
        }
    }
}
