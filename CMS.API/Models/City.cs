using System.ComponentModel.DataAnnotations;

namespace CMS.API.Models
{
    public class City
    {
        [Required(ErrorMessage = "City name is required")]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
