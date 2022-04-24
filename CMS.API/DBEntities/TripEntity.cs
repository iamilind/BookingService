using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DBEntities
{
    public class TripEntity
    {
        [Key]
        public int Id { get; set; }

        public int BookingId { get; set; }

        public int CabId { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime EndedAt { get; set; }

        [ForeignKey("CabId")]
        public CabEntity CabEntity { get; set; }
    }
}
