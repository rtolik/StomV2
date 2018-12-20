using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    public class PatientCategory
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual float Sale { get; set; }

        public virtual ISet<Patient> Patients { get; set; }

        public PatientCategory()
        {
        }

        public PatientCategory(string name, float sale)
        {
            Name = name;
            Sale = sale;
        }
    }
}
