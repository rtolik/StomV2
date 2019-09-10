using System;
using System.Drawing;
using System.IO;

namespace Stomatology.Models
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

        public Photo(string photoPath, string remark, Patient patient)
        {
            Id = null;
            PhotoPath = photoPath;
            Patient = patient;
            Remark = remark;
        }
    }
}
