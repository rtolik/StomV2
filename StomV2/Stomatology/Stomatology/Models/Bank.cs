namespace Stomatology.Models
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

    }
}