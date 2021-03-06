﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    public class priom
    {
        public virtual int id_pr { get; set; }
        
        public virtual DateTime data { get; set; }
        
        public virtual string diag { get; set; }

        public virtual string likuv { get; set; }

        public virtual float sale { get; set; }

        public virtual float suma { get; set; }

        public virtual int cat { get; set; }

        public virtual sl_likar likar { get; set; }

        public virtual fio fio { get; set; }

        public virtual sl_firm firma { get; set; }

        public virtual ISet<oper> opers { get; set; }

        public priom()
        {
        }

        public priom(int idPr, int firma, int fio, DateTime data, int likar, string diag, string likuv, float sale, float suma, int cat)
        {
            id_pr = idPr;
            this.firma.id = firma;
            this.fio.id = fio;
            this.data = data;
            this.likar.id_likar = likar;
            this.diag = diag;
            this.likuv = likuv;
            this.sale = sale;
            this.suma = suma;
            this.cat = cat;
        }
    }
}
