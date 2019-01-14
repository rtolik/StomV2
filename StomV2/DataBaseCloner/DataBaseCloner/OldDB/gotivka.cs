using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    public class gotivka
    {
        public virtual int id_got { get; set; }

        public virtual DateTime? data { get; set; }

        public virtual float suma { get; set; }

        public virtual string prim { get; set; }

        public virtual fio fio { get; set; }

        public virtual sl_firm firm { get; set; }

        public gotivka()
        {
        }

        
    }
}