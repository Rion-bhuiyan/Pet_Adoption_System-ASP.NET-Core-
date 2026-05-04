using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Pet
    {
        public int PetId { get; set; }

        [Required, StringLength(50), Display(Name = "Pet Name")]
        public string PetName { get; set; } = default!;

        [Required, Display(Name = "Adoption Fee")]
        public decimal AdoptionFee { get; set; }

        public virtual ICollection<AdoptionEntry> AdoptionEntries { get; set; } = new List<AdoptionEntry>();
    }
}