using System;
using System.Drawing;
using System.IO;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    public class Photo : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string PhotoPath { get; set; }

        public virtual string Remark { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual Patient Patient { get; set; }

        public Photo()
        {
            Id = null;
        }

        public Photo(string photoPath, int patientId, string remark)
        {
            Id = null;
            PhotoPath = photoPath;
            Patient.Id = patientId;
            Remark = remark;
        }

        public Photo(Foto photo, Patient patient)
        {
            Id = photo.id_foto;
            Remark = string.IsNullOrEmpty(photo.prim) ? "" : photo.prim;
            Date = photo.Data??DateTime.Today;
            Patient = patient;

            if (photo.foto != null)
            {
                Image img = new Bitmap(new MemoryStream(photo.foto));
                img.Save(Constants.PhotoSavePath + photo.id_foto + ".png");
                PhotoPath = Constants.PhotoSavePath + photo.id_foto + ".png";
            }
            else
                PhotoPath = Constants.NullPhotoPath;

        }
    }
}
