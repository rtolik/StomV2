using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    class Photo
    {
        public virtual int Id { get; set; }

        public virtual int PhotoPath { get; set; }

        public virtual int PatientId { get; set; }

        public virtual string Remark { get; set; }

        public Photo()
        {
        }

        public Photo(int id, int photoPath, int patientId, string remark)
        {
            Id = id;
            PhotoPath = photoPath;
            PatientId = patientId;
            Remark = remark;
        }
    }
}
