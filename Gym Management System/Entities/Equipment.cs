using System.ComponentModel.DataAnnotations;

namespace Gym_Management_System.Entities
{
    public class Equipment : BaseDto<long>
    {
        [Required]
        public string EquipmentName { get; set; } = string.Empty;
        [Required]
        public int Qty { get; set; }
        [Required]        
        public decimal Rate { get; set; }
        [Required]  
        public decimal TotalAmount{ get; set; }
    }   
}
