using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace project.Models.ViewModels
{
    public class AdopterVM
    {
        public int AdopterId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string AdopterName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birth date is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        public string? Picture { get; set; }

        public IFormFile? PictureFile { get; set; }

        public bool Maritalstatus { get; set; }

        public List<int> PetList { get; set; } = new List<int>();
    }
}