using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    class oper
    {
        public virtual int id_det { get; set; }

        public virtual int priom { get; set; } 

        public virtual int sl_operId { get; set; } //TODO write mapper for this

        public virtual int kol { get; set; }

        public virtual float sale { get; set; }

        public virtual float cena { get; set; }

        public virtual float suma { get; set; }

        public oper()
        {
        }

        public oper(int id_det, int priom, int sl_operId, int kol, float sale, float cena, float suma)
        {
            this.id_det = id_det;
            this.priom = priom;
            this.sl_operId = sl_operId;
            this.kol = kol;
            this.sale = sale;
            this.cena = cena;
            this.suma = suma;
        }
    }
}
