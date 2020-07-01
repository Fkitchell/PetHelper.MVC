using PetHelperMVC.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetHelper.Data
{
    public class Person : ApplicationUser
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}