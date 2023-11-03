using System.ComponentModel.DataAnnotations;

namespace Gym_Management_System.Entities
{
    public class BaseDto<T>
    {
        [Key]
        public T Id { get; set; } 
        //public int Version { get; set; }
    }
}
