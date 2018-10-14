using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    class PatientCat
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual float Sale { get; set; }

        public PatientCat()
        {
        }

        public PatientCat(int id, string name, float sale)
        {
            Id = id;
            Name = name;
            Sale = sale;
        }
    }
}
