﻿using PetHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Models.AppointmentModels
{
    public class AppointmentListDetail
    {
        public int AppointmentId { get; set; }
        [Display(Name = "Date and Time")]
        public DateTime DateTime { get; set; }

        public Pet Pet { get; set; }

        [Display(Name ="Service Provider")]
        public ServiceProvider ServiceProvider { get; set; }
        [Display(Name ="Type of Service")]
        public ServiceType ServiceType { get; set; }
    }
}
