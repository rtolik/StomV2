using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    class Patient
    {
        public virtual int Id { get; set; }

        public virtual string MedicalCard { get; set; }

        public virtual DateTime DateOfRegistration { get; set; }

        public virtual string FullName { get; set; }

        public virtual int PatientCardId { get; set; }

        public virtual int FirmId { get; set; }

        public virtual string Adress { get; set; }

        public virtual float Sale { get; set; }

        public virtual string Remark { get; set; }

        public virtual string Contraindications { get; set; }

        public virtual string IconPath { get; set; }

        public virtual bool IsPublic { get; set; }

        public Patient()
        {
        }

        public Patient(int id, string medicalCard, DateTime dateOfRegistration, 
            string fullName, int patientCardId, int firmId, string adress, float sale,
            string remark, string contraindications, string iconPath, bool isPublic)
        {
            Id = id;
            MedicalCard = medicalCard;
            DateOfRegistration = dateOfRegistration;
            FullName = fullName;
            PatientCardId = patientCardId;
            FirmId = firmId;
            Adress = adress;
            Sale = sale;
            Remark = remark;
            Contraindications = contraindications;
            IconPath = iconPath;
            IsPublic = isPublic;
        }
    }
}
