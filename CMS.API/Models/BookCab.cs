namespace CMS.API.Models
{
    public class BookCab
    {
        public string CustomerName { get; set; }        

        public int NumberofPassangers { get; set; }

        public int Distance { get; set; }   

        public int Location { get; set; }

    }

    public enum Status
    {
        BOOKED,

        ASSIGNED,

        CANCELLED,

        COMPLETED
    }
}
