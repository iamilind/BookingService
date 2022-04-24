namespace CMS.API.Models
{
    public class BookCab
    {
        public int CustomerId { get; set; }        

        public int Category { get; set; }

        public int CityId { get; set; }


    }

    public enum Status
    {
        INITIATED, 

        BOOKED,

        CANCELLED,

        COMPLETED
    }
}
