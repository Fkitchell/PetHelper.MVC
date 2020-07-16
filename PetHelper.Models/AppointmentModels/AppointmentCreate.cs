﻿using PetHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Models.AppointmentModels
{
    public class AppointmentCreate
    {
        [Display(Name = "Date and Time")]
        public DateTimeOffset DateTimeOffSet { get; set; }

        [Display(Name ="PetOwner")]
        public Guid PetOwnerId{ get; set; }

        public int PetId { get; set; }

        public string ServiceProviderId { get; set; }

        public ServiceType ServiceType { get; set; }
    }
}
