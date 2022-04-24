using System.ComponentModel.DataAnnotations;

namespace CMS.API.Models
{
    public class Cab
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int CityId { get; set; }

        public int Status { get; set; } = 0;

        [Required]
        public int DriverId { get; set; }   
    }

    public enum Categoty
    {
        SUV,

        SEDAN,

        HATCHBACK
    }

    public enum CabStatus
    {
        IDLE,
        ON_TRIP,
        IN_ACTIVE
    }
}