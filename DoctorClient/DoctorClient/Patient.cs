﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClient
{
    class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TajNumber { get; set; }
        public string Complaint { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}