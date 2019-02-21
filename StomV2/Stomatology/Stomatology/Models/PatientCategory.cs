using System.Collections.Generic;

namespace Stomatology.Models
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

        public override string ToString()
        {
            return Name;
        }
    }
}
