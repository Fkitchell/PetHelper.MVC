using PetHelperMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Data
{
    public enum ServiceType { Walking, Sitting, Grooming, Training, }
    public class ServiceProvider : ApplicationUser
    {
        [Display(Name ="Pet Specialties")]
        public List<PetType>  PetSpecialities { get; set; }

        [Display(Name = "Services Offered")]
        public List<ServiceType> ServiceTypes { get; set; }
    }
}
