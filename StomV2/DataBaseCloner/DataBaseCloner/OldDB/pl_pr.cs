using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    class pl_pr
    {
        public virtual int id_pr { get; set; }

        public virtual int firma { get; set; }

        public virtual int fio { get; set; }

        public virtual DateTime data { get; set; }

        public virtual int likar { get; set; }

        public virtual string diag { get; set; }

        public virtual string likuv { get; set; }

        public virtual float sale { get; set; }

        public virtual float suma { get; set; }

        public virtual int cat { get; set; }

        public pl_pr()
        {
        }

        public pl_pr(int id_pr, int firma, int fio, DateTime data, int likar,
            string diag, string likuv, float sale, float suma, int cat)
        {
            this.id_pr = id_pr;
            this.firma = firma;
            this.fio = fio;
            this.data = data;
            this.likar = likar;
            this.diag = diag;
            this.likuv = likuv;
            this.sale = sale;
            this.suma = suma;
            this.cat = cat;
        }
    }
}
