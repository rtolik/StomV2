﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    public class sl_op_op
    {
        public virtual int id_op { get; set; }
        
        public virtual string n_op { get; set; }

        public virtual float cena { get; set; }

        public virtual sl_op_roz id_rozd { get; set; }

        public virtual ISet<material> materials { get; set; }

        public virtual ISet<pl_oper> pl_opers { get; set; }

        public virtual ISet<oper> opers { get; set; }


        public sl_op_op()
        {
        }

        public sl_op_op(int idOp, int idRozd, string nOp, float cena)
        {
            id_op = idOp;
            id_rozd.id_roz = idRozd;
            n_op = nOp;
            this.cena = cena;
        }
    }
}
