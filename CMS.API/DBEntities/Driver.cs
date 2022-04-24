using System.ComponentModel.DataAnnotations;

namespace CMS.API.DBEntities
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactDetails { get; set; }
    }
}
