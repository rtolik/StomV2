﻿using System;

namespace DataBaseCloner.NewDB
{
    public class Photo
    {
        public virtual int Id { get; set; }

        public virtual string PhotoPath { get; set; }

        public virtual string Remark { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual Patient Patient { get; set; }

        public Photo() {}

        public Photo(string photoPath, int patientId, string remark)
        {
            PhotoPath = photoPath;
            Patient.Id = patientId;
            Remark = remark;
        }
    }
}
