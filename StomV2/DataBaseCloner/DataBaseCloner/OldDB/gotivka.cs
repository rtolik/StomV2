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

        public virtual int fio { get; set; }

        public virtual int firma { get; set; }

        public virtual DateTime data { get; set; }

        public virtual float suma { get; set; }

        public virtual string prim { get; set; }

        public virtual ISet<fio> fios { get; set; }

        public virtual ISet<sl_firm> firms { get; set; }

        public gotivka()
        {
        }

        public gotivka(int idGot, int fio, int firma, DateTime data, float suma, string prim, ISet<fio> fios, ISet<sl_firm> firms)
        {
            id_got = idGot;
            this.fio = fio;
            this.firma = firma;
            this.data = data;
            this.suma = suma;
            this.prim = prim;
            this.fios = fios;
            this.firms = firms;
        }
    }
}