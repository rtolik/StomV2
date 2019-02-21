using DataBaseCloner.OldDB;

namespace Sromatology.Models
{
    public class Bank : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string SplitAccount { get; set; }

        public virtual string Name { get; set; }

        public virtual string Mfo { get; set; }

        public virtual string DayCash { get; set; }

        public virtual string EveningCash { get; set; }

        public virtual string Person { get; set; }

        public virtual Firm Firm { get; set; }

        public Bank()
        {
            Id = null;
        }

        public Bank(string splitAccount, string name, string mfo, string dayCash,
            string eveningCash, Firm firm)
        {
            Id = null;
            SplitAccount = splitAccount;
            Name = name;
            Mfo = mfo;
            DayCash = dayCash;
            EveningCash = eveningCash;
            Firm = firm;
        }

        public Bank(Firm firm, sl_firm sl_firm, bool firstTime)
        {
            Id = null;
            if (firstTime)
            {
                Name = sl_firm.bank1??"";
                DayCash = sl_firm.kd1??"";
                EveningCash = sl_firm.kv1??"";
                Mfo = sl_firm.mfo1??"";
                SplitAccount = sl_firm.rr1??"";
                Person = sl_firm.ch1??"";
            }
            else
            {
                Name = sl_firm.bank2??"";
                DayCash = sl_firm.kd2??"";
                EveningCash = sl_firm.kv2??"";
                Mfo = sl_firm.mfo2??"";
                SplitAccount = sl_firm.rr2??"";
                Person = sl_firm.ch2??"";
            }

            Firm = firm;
        }
    }
}