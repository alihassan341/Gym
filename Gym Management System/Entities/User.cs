using Gym_Management_System.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym_Management_System.Entities
{
    public class User : BaseDto<long>
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string FathereName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Password)]        
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [Phone]
        public string Phone { get; set; } = string.Empty;
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string Cnic { get; set; }
        public int Age { get; set; }        
        public DateTime? Timing { get; set; }
    }
}

