using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    public class pl_oper
    {
        public virtual int id_det { get; set; }
        
        public virtual int kol { get; set; }

        public virtual float sale { get; set; }

        public virtual float cena { get; set; }

        public virtual float suma { get; set; }

        public virtual sl_op_op oper { get; set; }

        public virtual pl_pr priom { get; set; }

        public pl_oper()
        {
        }

        public pl_oper(int idDet, int priom, int slOperId, int kol, float sale, float cena, float suma)
        {
            id_det = idDet;
            this.priom.id_pr = priom;
            oper.id_op = slOperId;
            this.kol = kol;
            this.sale = sale;
            this.cena = cena;
            this.suma = suma;
        }
    }
}
