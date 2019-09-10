using System;
using System.Collections.Generic;

namespace Stomatology.Models
{
    public class Visit : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Diagnosis { get; set; }

        public virtual string Terapy { get; set; }

        public virtual float Sale { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual float Summ { get; set; }

        public virtual bool IsDone { get; set; }

        public virtual ISet<Operation> Operations { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual VisitCategory VisitCategory { get; set; }


        public Visit()
        {
            Id = null;
        }

        public Visit(string diagnosis, string terapy, float sale,
            float summ, DateTime date, VisitCategory visitCategory, Firm firm,
            Patient patient, Doctor doctor)
        {
            Id = null;
            Diagnosis = diagnosis;
            Terapy = terapy;
            Sale = sale;
            VisitCategory = visitCategory;
            Summ = summ;
            Firm = firm;
            Patient = patient;
            Doctor = doctor;
            Date = date;
        }
    }
}