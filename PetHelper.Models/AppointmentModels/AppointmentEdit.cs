﻿using PetHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Models.AppointmentModels
{
    public class AppointmentEdit
    {
        public string ServiceProviderId { get; set; }

        public int AppoinmentId { get; set; }
        [Display(Name = "Date and Time")]
        public DateTimeOffset DateTimeOffSet { get; set; }

        [Display(Name = "Pet Owner")]
        public PetOwner PetOwner { get; set; }

        public Pet Pet { get; set; }

        public ServiceType ServiceType { get; set; }
    }
}
