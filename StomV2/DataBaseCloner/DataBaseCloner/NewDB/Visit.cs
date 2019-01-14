using System;
using System.Collections.Generic;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
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
            int visitCategoryId, float summ, int firmId,
            int patientId, int doctorId, DateTime date)
        {
            Id = null;
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

        public Visit(priom priom, VisitCategory category, Firm firm, Doctor doctor, Patient patient)
        {
            Id = priom.id_pr;
            Date = priom.data;
            Diagnosis = priom.diag ?? "";
            Terapy = priom.likuv ?? "";
            Sale = priom.sale;
            Summ = priom.suma;
            IsDone = true;
            Firm = firm;
            Doctor = doctor;
            Patient = patient;
            VisitCategory = category;
        }
        public Visit(pl_pr priom, VisitCategory category, Firm firm, Doctor doctor, Patient patient)
        {
            Id = priom.id_pr;
            Date = priom.data;
            Diagnosis = priom.diag ?? "";
            Terapy = priom.likuv ?? "";
            Sale = priom.sale;
            Summ = priom.suma;
            IsDone = false;
            Firm = firm;
            Doctor = doctor;
            Patient = patient;
            VisitCategory = category;
        }

    }
}