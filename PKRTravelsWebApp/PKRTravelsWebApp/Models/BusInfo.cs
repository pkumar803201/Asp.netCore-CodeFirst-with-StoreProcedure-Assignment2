using System.ComponentModel.DataAnnotations;

namespace PKRTravelsWebApp.Models
{
    public class BusInfo
    {
        [Key,Required]
        public int BusId { get; set; }
        [Required]
        public string BoardingPoint { get; set; }
        public DateTime TravelDate { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public int Rating { get; set; }
       /* public string Response { get; set; }*/
    }
}
