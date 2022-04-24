using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DBEntities
{
    public class CabEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public string Number { get; set; }

        public int Category { get; set; }

        public int CityId { get; set; }

        public bool IsActive { get; set; }

        public string DriveName { get; set; }

        [ForeignKey("CityId")]
        public CityEntity CityEntity { get; set; }
    }
}
