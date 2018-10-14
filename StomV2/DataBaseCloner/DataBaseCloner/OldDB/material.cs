using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    class material
    {
        public virtual int id { get; set; }

        public virtual DateTime data { get; set; }

        public virtual string tip { get; set; }

        public virtual int mat { get; set; }

        public virtual int kol { get; set; }

        public virtual float cena { get; set; }

        public virtual float suma { get; set; }

        public material()
        {
        }

        public material(int id, DateTime data, string tip, int mat, int kol, float cena, float suma)
        {
            this.id = id;
            this.data = data;
            this.tip = tip;
            this.mat = mat;
            this.kol = kol;
            this.cena = cena;
            this.suma = suma;
        }
    }
}
