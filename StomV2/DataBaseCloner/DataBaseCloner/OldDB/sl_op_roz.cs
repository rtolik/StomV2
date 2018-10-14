using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    class sl_op_roz
    {
        public virtual int id_roz { get; set; }

        public virtual string n_roz { get; set; }

        public virtual bool druk { get; set; }

        public sl_op_roz()
        {
        }

        public sl_op_roz(int id_roz, string n_roz, bool druk)
        {
            this.id_roz = id_roz;
            this.n_roz = n_roz;
            this.druk = druk;
        }
    }
}
