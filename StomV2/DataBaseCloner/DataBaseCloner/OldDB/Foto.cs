using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    class Foto
    {
        public virtual int id_foto { get; set; }

        public virtual int fio { get; set; }

        public virtual int firma { get; set; }

        public virtual DateTime Data { get; set; }

        public virtual string prim { get; set; }

        public virtual Image foto { get; set; }

        public Foto()
        {
        }

        public Foto(int id_foto, int fio, int firma, DateTime data, string prim, Image foto)
        {
            this.id_foto = id_foto;
            this.fio = fio;
            this.firma = firma;
            Data = data;
            this.prim = prim;
            this.foto = foto;
        }
    }
}
