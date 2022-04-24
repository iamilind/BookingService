namespace CMS.API.Models
{
    public class BookingDetails
    {
        public int BookingId { get; set; }

        public Cab CabDetails { get; set;}

        public Status Status { get; set; }
    }
}