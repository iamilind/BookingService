namespace CMS.API.Models
{
    public class BookCabResponse
    {
        public int BookingId { get; set; }  

        public decimal Amount { get; set; }

        public Status BookingStatus { get; set; }   
    }
}
