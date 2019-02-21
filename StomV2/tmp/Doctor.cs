using System.Collections.Generic;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
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

        public Doctor(sl_likar likar, Firm firm)
        {
            Id = likar.id_likar;
            FullName = likar.n_likar;
            Firm = firm;
        }
    }
}