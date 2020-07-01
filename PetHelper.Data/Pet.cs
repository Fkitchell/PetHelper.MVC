using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Data
{
    public class Pet
    {
        [Key]
        public Guid PetId { get; set; }
        [Required]
        [Display(Name = "Pet's Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Type of Pet")]
        public string Type { get; set; }
        public virtual PetOwner PetOwner { get; set; }
    }
}
