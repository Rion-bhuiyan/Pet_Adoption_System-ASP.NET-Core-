using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Adopter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdopterId { get; set; }

        [Required, StringLength(50), Display(Name = "Adopter Name")]
        public string AdopterName { get; set; } = default!;

        [Required, Display(Name = "Date of Birth"), Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public string? Picture { get; set; }

        [Display(Name = "Marital Status")]
        public bool MaritalStatus { get; set; }

        public virtual ICollection<AdoptionEntry> AdoptionEntries { get; set; } = new List<AdoptionEntry>();
    }
}