using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class AdoptionEntry
    {
        public int AdoptionEntryId { get; set; }

        [ForeignKey("Pet"), Required]
        public int PetId { get; set; }

        [ForeignKey("Adopter"), Required]
        public int AdopterId { get; set; }

        public virtual Adopter? Adopter { get; set; }
        public virtual Pet? Pet { get; set; }
    }
}