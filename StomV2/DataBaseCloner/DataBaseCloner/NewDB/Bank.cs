using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    public class Bank
    {
        public virtual int Id { get; set; }

        public virtual string SplitAccount { get; set; }

        public virtual string Name { get; set; }

        public virtual string  Mfo { get; set; }

        public virtual string DayCash { get; set; }

        public virtual string EveningCash { get; set; }

        public virtual string Person { get; set; }

        public virtual Firm Firm { get; set; }

        public Bank()
        {
        }

        public Bank( string splitAccount, string name, string mfo, string dayCash,
            string eveningCash, Firm firm)
        {
            SplitAccount = splitAccount;
            Name = name;
            Mfo = mfo;
            DayCash = dayCash;
            EveningCash = eveningCash;
            Firm = firm;
        }

        public Bank(sl_firm firm, bool firstTime)
        {
            if (firstTime)
            {
                this.Name = firm.bank1;
                this.DayCash = firm.kd1;
                this.EveningCash = firm.kv1;
                this.Mfo = firm.mfo1;
                this.SplitAccount = firm.rr1;
                this.Person = firm.ch1;
            }
            else
            {
                this.Name = firm.bank2;
                this.DayCash = firm.kd2;
                this.EveningCash = firm.kv2;
                this.Mfo = firm.mfo2;
                this.SplitAccount = firm.rr2;
                this.Person = firm.ch2;
            }

            this.Firm.Id = firm.id;
        }
    }
}
