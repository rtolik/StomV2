using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    class Visit
    {
        public virtual int Id { get; set; }

        public virtual int FirmId { get; set; }

        public virtual int PatientId { get; set; }

        public virtual int DoctorId { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual string Diagnosis { get; set; }

        public virtual string Terapy { get; set; }

        public virtual float Sale { get; set; }

        public virtual int VisitCategoryId { get; set; }

        public virtual float Summ { get; set; }

        public Visit()
        {
        }

        public Visit(int id, int firmId, int patientId, int doctorId, DateTime date, 
            string diagnosis, string terapy, float sale, int visitCategoryId, float summ)
        {
            Id = id;
            FirmId = firmId;
            PatientId = patientId;
            DoctorId = doctorId;
            Date = date;
            Diagnosis = diagnosis;
            Terapy = terapy;
            Sale = sale;
            VisitCategoryId = visitCategoryId;
            Summ = summ;
        }
    }
}
