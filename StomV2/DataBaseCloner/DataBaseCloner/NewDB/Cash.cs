using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    class Cash
    {
        public virtual int Id { get; set; }

        public virtual int PatientId { get; set; }

        public virtual int FirmId { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual float Value { get; set; }

        public virtual int Remark { get; set; }

        public Cash()
        {
        }

        public Cash(int id, int patientId, int firmId, DateTime date, float value, int remark)
        {
            Id = id;
            PatientId = patientId;
            FirmId = firmId;
            Date = date;
            Value = value;
            Remark = remark;
        }
    }
}