using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    public class PhoneNumber : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Phone { get; set; }

        public virtual Patient Patient { get; set; }

        public PhoneNumber()
        {
            Id = null;
        }

        public PhoneNumber( string phone, int patientId)
        {
            Id = null;
            Phone = phone;
            Patient.Id = patientId;
        }

        public PhoneNumber(Patient patient, fio fio, bool isfirst)
        {
            if (isfirst)
                if (!string.IsNullOrEmpty(fio.tel1))
                    Phone = fio.tel1;
                else
                    Phone = "";
            else
                if (!string.IsNullOrEmpty(fio.tel2))
                    Phone = fio.tel2;
                else
                    Phone = "";
            Patient = patient;
        }
    }
}
