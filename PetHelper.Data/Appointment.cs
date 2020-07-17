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
        [Key]
        public int AppointmentId { get; set; }

        [Display(Name = "Date and Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        public DateTime DateTime { get; set; }

        //[ForeignKey("PetOwner")]   //consider removing this because Pet has a FK of PetOwner, and if there is an Appointment tied to a pet, then it is inherently tied to the PetOwner of that Pet
        //[Required]
        //public Guid PetOwnerId { get; set; }

        //[Display(Name = "Pet Owner")]
        //public virtual PetOwner PetOwner { get; set; }

        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }

        [ForeignKey("ServiceProvider")]
        [Display(Name = "Service Provider")]
        //[Required]
        public string ServiceProviderId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }

        [Required]
        [Display(Name = "Type of Service")]
        public ServiceType ServiceType { get; set; }
    }
}
