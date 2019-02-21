using System.Collections.Generic;

namespace Stomatology.Models
{
    public class Doctor : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string FullName { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual ISet<Visit> Visits { get; set; }

        public Doctor()
        {
            Id = null;
        }

        public Doctor(string fullName, int firmId)
        {
            Id = null;
            FullName = fullName;
            Firm.Id = firmId;
        }

    }
}