namespace CMS.API.Models
{
    public class Cab
    {
        public string Model { get; set; }

        public string Number { get; set; }

        public Categoty Category { get; set; }

        public int CityId { get; set; }

        public bool IsActive { get; set; }

        public string DriveName { get; set; }   
    }

    public enum Categoty
    {
        SUV,

        SEDAN,

        HATCHBACK
    }
}