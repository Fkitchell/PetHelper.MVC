using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Data
{
    public enum ServiceType { Walking, Sitting, Grooming, Training, }
    public class ServiceProvider : Person
    {
        [Display(Name ="Pet Specialities")]
        public List<string>  PetSpecialities { get; set; }
        [Display(Name = "Services Offered")]
        public List<ServiceType> ServiceTypes { get; set; }
    }
}
