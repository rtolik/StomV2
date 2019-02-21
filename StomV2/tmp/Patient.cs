using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    public class Patient : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string MedicalCard { get; set; }

        public virtual DateTime DateOfRegistration { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Adress { get; set; }

        public virtual float Sale { get; set; }

        public virtual string Remark { get; set; }

        public virtual string Contraindications { get; set; }

        public virtual string IconPath { get; set; }

        public virtual bool IsPublic { get; set; }

        public virtual ISet<Photo> Photos { get; set; }

        public virtual ISet<PhoneNumber> PhoneNumbers { get; set; }

        public virtual ISet<Visit> Visits { get; set; }

        public virtual ISet<Cash> Cashes { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual PatientCategory PatientCategory { get; set; }


        public Patient()
        {
            Id = null;
        }

        public Patient(string medicalCard, DateTime dateOfRegistration, 
            string fullName, int patientCatId, int firmId, string adress, float sale,
            string remark, string contraindications, string iconPath, bool isPublic)
        {
            Id = null;
            MedicalCard = medicalCard;
            DateOfRegistration = dateOfRegistration;
            FullName = fullName;
            PatientCategory.Id = patientCatId;
            Firm.Id = firmId;
            Adress = adress;
            Sale = sale;
            Remark = remark;
            Contraindications = contraindications;
            IconPath = iconPath;
            IsPublic = isPublic;
        }

        public Patient(fio fio, PatientCategory category, Firm firm)
        {
            Id = fio.id;
            MedicalCard = fio.nomer.ToString();
            DateOfRegistration = fio.datar;
            FullName = fio.fio_name;
            Adress = fio.adres;
            Sale = fio.sales ?? 0;
            Remark = fio.prim;
            Contraindications = fio.proti; 
            IsPublic = fio.zagal??true;
            if (fio.foto != null)
            {
                Image img = new Bitmap(new MemoryStream(fio.foto));
                img.Save(Constants.IconSavePath + FullName + ".png");
                IconPath = Constants.IconSavePath + FullName + ".png";
            }
            else
            {
                IconPath = Constants.NullIconPhotoPath;
            }
            
            PatientCategory = category;
            Firm = firm;
        }
    }
}
