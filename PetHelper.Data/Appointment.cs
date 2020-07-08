using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Data
{
    public class Appointment
    {
        [Display(Name = "Date and Time")]
        [Required]
        public DateTimeOffset DateAndTime { get; set; }

        [ForeignKey("PetOwner")]
        [Required]
        public Guid PetOwnerId { get; set; }

        [Display(Name = "Pet Owner")]
        public virtual PetOwner PetOwner { get; set; }
        
        public virtual Pet Pet { get; set; }

        [ForeignKey("ServiceProvider")]
        [Display(Name = "Service Provider")]
        [Required]
        public Guid ServiceProviderId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }

        [Required]
        [Display(Name = "Type of Service")]
        public ServiceType ServiceType { get; set; }
    }
}
