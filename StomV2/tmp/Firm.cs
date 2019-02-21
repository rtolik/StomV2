using System.Collections.Generic;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    public class Firm : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

        public virtual bool IsPatientPublic { get; set; }

        public virtual ISet<Patient> Patients { get; set; }

        public virtual ISet<Visit> Visits { get; set; }

        public virtual ISet<Cash> Cashes { get; set; }

        public virtual ISet<Bank> Banks { get; set; }

        public virtual ISet<Doctor> Doctors { get; set; }

        public Firm()
        {
            Id = null;
        }

        public Firm(string name, string code, bool isPatientPublic)
        {
            Id = null;
            Name = name;
            Code = code;
            IsPatientPublic = isPatientPublic;
        }

        public Firm(int id,string name, string code, bool isPatientPublic)
        {
            Id = id;
            Name = name;
            Code = code;
            IsPatientPublic = isPatientPublic;
        }

        public Firm(sl_firm firm)
        {
            Id = firm.id;
            Name = firm.name;
            Code = firm.kod;
            IsPatientPublic = firm.zagal;
        }
    }
}