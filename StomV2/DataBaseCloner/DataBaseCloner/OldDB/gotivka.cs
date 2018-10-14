using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    class gotivka
    {
        public virtual int id_got { get; set; }

        public virtual int fio { get; set; }

        public virtual int firma { get; set; }

        public virtual DateTime data { get; set; }

        public virtual float suma { get; set; }

        public virtual string prim { get; set; }

        public gotivka()
        {
        }

        public gotivka(int id_got, int fio, int firma, DateTime data, float suma, string prim)
        {
            this.id_got = id_got;
            this.fio = fio;
            this.firma = firma;
            this.data = data;
            this.suma = suma;
            this.prim = prim;
        }
    }
}