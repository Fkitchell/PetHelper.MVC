using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Data
{
    public enum PetType { Dog, Cat, Rabbit, Ferret, Pig, Rodent, Bird, Turtle, Lizards, Snake, Fish, Frog, Salamander, Spider, Other }

    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        [Display(Name = "Pet's Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Type of Pet")]
        public PetType PetType { get; set; }

        [ForeignKey("PetOwner")]
        public Guid PetOwnerId { get; set; }
        public virtual PetOwner PetOwner { get; set; }
    }
}
