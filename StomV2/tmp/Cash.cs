using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    public class Cash : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual float Value { get; set; }

        public virtual string Remark { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Firm Firm { get; set; }


        public Cash()
        {
            Id = null;
        }

        public Cash(int patientId, int firmId, DateTime date, float value, string remark)
        {
            Id = null;
            Patient.Id = patientId;
            Firm.Id = firmId;
            Date = date;
            Value = value;
            Remark = remark;
        }

        public Cash(gotivka gotivka, Patient patient, Firm firm)
        {
            Id = gotivka.id_got;
            Date = gotivka.data??DateTime.Today;
            Value = gotivka.suma;
            Remark = gotivka.prim;
            Patient = patient;
            Firm = firm;
        }
    }
}