using System.ComponentModel.DataAnnotations;

namespace Gym_Management_System.Entities
{
    public class Admin : BaseDto<long>
    {
        public string FullName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string Cnic { get; set; } = string.Empty;
        public int Age { get; set; }
        //public int Advancefee { get; set; }
        //public int Monthlyfee { get; set; }
        //public DateTime OpeningTime{ get; set; }        
        //public DateTime ClosingDate { get; set; }
        //public DateTime? OfferOpeningDate{ get; set; }
        //public DateTime? OfferClosingDate{ get; set; }
    }
}


