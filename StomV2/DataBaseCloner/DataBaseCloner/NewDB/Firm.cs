using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    public class Firm
    {
        public virtual int Id { get; set; }

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
        }

        public Firm(string name, string code, bool isPatientPublic)
        {
            this.Name = name;
            this.Code = code;
            this.IsPatientPublic = isPatientPublic;
        }

        public Firm(sl_firm firm)
        {
            this.Id = firm.id;
            this.Name = firm.name;
            this.Code = firm.kod;
            this.IsPatientPublic = firm.zagal;
        }
    }
}
