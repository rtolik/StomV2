using System;
using System.Collections.Generic;

namespace DataBaseCloner.NewDB
{
    public class Visit
    {
        public virtual int Id { get; set; }

        public virtual string Diagnosis { get; set; }

        public virtual string Terapy { get; set; }

        public virtual float Sale { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual float Summ { get; set; }

        public virtual ISet<Operation> Operations { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual VisitCategory VisitCategory { get; set; }


        public Visit()
        {
        }

        public Visit(string diagnosis, string terapy, float sale,
            int visitCategoryId, float summ, int firmId,
            int patientId, int doctorId, DateTime date)
        {
            Diagnosis = diagnosis;
            Terapy = terapy;
            Sale = sale;
            VisitCategory.Id = visitCategoryId;
            Summ = summ;
            Firm.Id = firmId;
            Patient.Id = patientId;
            Doctor.Id = doctorId;
            Date = date;
        }

    }
}