﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    public class PhoneNumber
    {
        public virtual int Id { get; set; }

        public virtual string Phone { get; set; }

        public virtual Patient Patient { get; set; }

        public PhoneNumber()
        {
        }

        public PhoneNumber(int id, string phone, int patientId)
        {
            Id = id;
            Phone = phone;
            Patient.Id = patientId;
        }
    }
}
