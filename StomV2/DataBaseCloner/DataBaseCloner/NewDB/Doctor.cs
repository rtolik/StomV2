using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
   public class Doctor
    {
        public virtual int Id { get; set; }
        
        public virtual string FullName { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual ISet<Visit> Visits { get; set; }

        public Doctor()
        {
        }

        public Doctor(string fullName, int firmId)
        {
            this.FullName = fullName;
            this.Firm.Id = firmId;
        }
    }
}
