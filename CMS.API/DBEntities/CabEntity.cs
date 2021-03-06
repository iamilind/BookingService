using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DBEntities
{
    public class CabEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Number { get; set; }

        public int Category { get; set; }

        public int CityId { get; set; }

        public int Status { get; set; }

        public DateTime LastTripEndedAt { get; set; }

        public int DriverId { get; set; }

        [ForeignKey("CityId")]
        public CityEntity CityEntity { get; set; }

        [ForeignKey("DriverId")]
        public Driver DriverEntity { get; set; }
    }
}
