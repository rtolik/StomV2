using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    class Bank
    {
        public virtual int Id { get; set; }

        public virtual string SplitAccount { get; set; }

        public virtual string Name { get; set; }

        public virtual string  Mfo { get; set; }

        public virtual string DayCash { get; set; }

        public virtual string EveningCash { get; set; }

        public virtual string Person { get; set; }

        public virtual string FirmId { get; set; }

        public Bank()
        {
        }

        public Bank(int id, string splitAccount, string name, string mfo, string dayCash,
            string eveningCash, string person, string firmId)
        {
            Id = id;
            SplitAccount = splitAccount;
            Name = name;
            Mfo = mfo;
            DayCash = dayCash;
            EveningCash = eveningCash;
            Person = person;
            FirmId = firmId;
        }
    }
}
