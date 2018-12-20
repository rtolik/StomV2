using System;
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

        public PhoneNumber( string phone, int patientId)
        {
            Phone = phone;
            Patient.Id = patientId;
        }
    }
}
