using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    public class sl_firm
    {
        public virtual int id { get; set; }

        public virtual string name { get; set; }

        public virtual string kod { get; set; }

        public virtual string rr1 { get; set; }

        public virtual string bank1 { get; set; }

        public virtual string mfo1 { get; set; }

        public virtual string kd1 { get; set; }

        public virtual string kv1 { get; set; }

        public virtual string rr2 { get; set; }

        public virtual string bank2 { get; set; }

        public virtual string mfo2 { get; set; }

        public virtual string kd2 { get; set; }

        public virtual string kv2 { get; set; }

        public virtual string ch1 { get; set; }

        public virtual string ch2 { get; set; }

        public virtual bool zagal { get; set; }

        public virtual ISet<Foto> fotos { get; set; }

        public virtual ISet<priom> prioms { get; set; }

        public virtual ISet<gotivka> gotivkas { get; set; }


        public sl_firm()
        {
        }

        public sl_firm(int id, string name, string kod, string rr1, string bank1, string mfo1, string kd1, string kv1, string rr2, string bank2, string mfo2, string kd2, string kv2, string ch1, string ch2, bool zagal)
        {
            this.id = id;
            this.name = name;
            this.kod = kod;
            this.rr1 = rr1;
            this.bank1 = bank1;
            this.mfo1 = mfo1;
            this.kd1 = kd1;
            this.kv1 = kv1;
            this.rr2 = rr2;
            this.bank2 = bank2;
            this.mfo2 = mfo2;
            this.kd2 = kd2;
            this.kv2 = kv2;
            this.ch1 = ch1;
            this.ch2 = ch2;
            this.zagal = zagal;
        }
    }
}
