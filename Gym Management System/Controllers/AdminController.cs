using Gym_Management_System.Entities;
using Gym_Management_System.Entities.Auth;
using Gym_Management_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Gym_Management_System.Controllers
{

    [Authorize(Roles = UserRoles.Admin)]
    //[Authorize]
    //[Area("Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpPost("Create")]
        public ActionResult<Admin> Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _adminRepository.Create(admin);
                _adminRepository.Save();
            }
            else
            {
                return BadRequest(ModelState);
            }
            return Ok(this.GetAll());
        }

        [HttpPut("Update")]
        public ActionResult<Admin> Put(Admin Admin)
        {
            if (ModelState.IsValid)
            {
                _adminRepository.Update(Admin);
                _adminRepository.Save();
            }
            else
            {
                return BadRequest(ModelState);

            }
            return Ok(this.GetAll());
        }


        [HttpGet("GetAll")]
//        [Authorize(Roles = UserRoles.Admin)]
        public IList<Admin> GetAll()
        {
            return _adminRepository.GetAll();
        }


        [HttpGet("GetById")]
        [Authorize(Roles = UserRoles.Admin)]
        public IList<Admin> GetById(ref long Id)
        {
            return _adminRepository.GetById(Id);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long Id)
        {
            _adminRepository.Delete(Id);
            _adminRepository.Save();
            return Ok("Deleted Successfully");
        }
        //[HttpPost("TestAPI")]
        //public void Test(Admin entity)
        //{
        //    _adminRepository.Update(entity);
        //}
        [HttpPost("CreateEmptyExcelFileAndGetGuid")]
        public string CreateEmptyExcelFileAndGetGuid(string FileName)
        {
            return General.CreateEmptyExcelFileAndGetGuid(FileName);
        }

        [HttpPost("Exceltobase64")]
        public byte[] Exceltobase64(string FilePath)
        {
            return General.ConvertExcelToByteArray(FilePath);
        }

        [HttpPost("ExportBase64ToExcelAndGetGuid")]
        public string ExportBase64ToExcelAndGetGuid(string FileName,byte[] Format)
        {
            return General.ExportBase64ToExcelAndGetGuid(FileName,Format);
        }
        
    }
}
