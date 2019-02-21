using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    public class PatientCategory : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual float Sale { get; set; }

        public virtual ISet<Patient> Patients { get; set; }

        public PatientCategory()
        {
            Id = null;
        }

        public PatientCategory(string name, float sale)
        {
            Id = null;
            Name = name;
            Sale = sale;
        }

        public PatientCategory(sl_cat category)
        {
            Id = category.id_cat;
            Name = category.n_cat;
            Sale = 0;
        }
    }
}
