using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    public class sl_op_roz
    {
        public virtual int id_roz { get; set; }

        public virtual string n_roz { get; set; }

        public virtual bool druk { get; set; }

        public virtual ISet<sl_op_op> sl_op_ops { get; set; }


        public sl_op_roz()
        {
        }

        public sl_op_roz(int idRoz, string nRoz, bool druk)
        {
            id_roz = idRoz;
            n_roz = nRoz;
            this.druk = druk;
        }
    }
}
