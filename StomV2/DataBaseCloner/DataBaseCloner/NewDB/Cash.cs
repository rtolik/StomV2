using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    public class Cash
    {
        public virtual int Id { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual float Value { get; set; }

        public virtual string Remark { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Firm Firm { get; set; }


        public Cash()
        {
        }

        public Cash(int patientId, int firmId, DateTime date, float value, string remark)
        {
            Patient.Id = patientId;
            Firm.Id = firmId;
            Date = date;
            Value = value;
            Remark = remark;
        }
    }
}