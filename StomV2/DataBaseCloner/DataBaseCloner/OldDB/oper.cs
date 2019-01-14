using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    public class oper
    {
        public virtual int id_det { get; set; }

        public virtual int kol { get; set; }

        public virtual float sale { get; set; }

        public virtual float cena { get; set; }

        public virtual float suma { get; set; }

        public virtual sl_op_op sl_operId { get; set; } 

        public virtual priom priom { get; set; }


        public oper()
        {
        }

        public oper(int id_det, int priom, int sl_operId, int kol, float sale, float cena, float suma)
        {
            this.id_det = id_det;
            this.priom.id_pr = priom;
            this.sl_operId.id_op = sl_operId;
            this.kol = kol;
            this.sale = sale;
            this.cena = cena;
            this.suma = suma;
        }
    }
}
