using System;
using System.Collections.Generic;
using Stomatology.Models.Interfaces;

namespace Stomatology.Models
{
    public class Patient : IEntityble
    {
        public virtual string MedicalCard { get; set; }

        public virtual DateTime DateOfRegistration { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Adress { get; set; }

        public virtual float Sale { get; set; }

        public virtual string Remark { get; set; }

        public virtual string Contraindications { get; set; }

        public virtual string IconPath { get; set; }

        public virtual bool IsPublic { get; set; }

        public virtual bool IsArchive { get; set; }

        public virtual IList<Photo> Photos { get; set; }

        public virtual IList<PhoneNumber> PhoneNumbers { get; set; }

        public virtual IList<Visit> Visits { get; set; }

        public virtual IList<Cash> Cashes { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual PatientCategory PatientCategory { get; set; }


        public Patient()
        {
            Id = null;
        }

        public Patient(string medicalCard, DateTime dateOfRegistration, string fullName, string adress, float sale,
            string remark, string contraindications, string iconPath, bool isPublic, bool isArchive, List<Photo> photos,
            List<PhoneNumber> phoneNumbers, List<Visit> visits, List<Cash> cashes, Firm firm,
            PatientCategory patientCategory)
        {
            Id = null;
            MedicalCard = medicalCard;
            DateOfRegistration = dateOfRegistration;
            FullName = fullName;
            Adress = adress;
            Sale = sale;
            Remark = remark;
            Contraindications = contraindications;
            IconPath = iconPath;
            IsPublic = isPublic;
            IsArchive = isArchive;
            Photos = photos;
            PhoneNumbers = phoneNumbers;
            Visits = visits;
            Cashes = cashes;
            Firm = firm;
            PatientCategory = patientCategory;
        }

        public virtual int? Id { get; set; }
    }
}