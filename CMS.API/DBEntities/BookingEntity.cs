using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DBEntities
{
    public class BookingEntity
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Category { get; set; }

        public int CityId { get; set; }

        public int? CabId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }

        [ForeignKey("CityId")]
        public CityEntity CityEntity { get; set; }

        [ForeignKey("UserId")]
        public User UserEntity { get; set; }

        [ForeignKey("CabId")]
        public CabEntity CabEntity { get; set; }
    }
}
