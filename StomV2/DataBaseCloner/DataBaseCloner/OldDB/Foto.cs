using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    public class Foto
    {
        public virtual int id_foto { get; set; }

        public virtual DateTime? Data { get; set; }

        public virtual string prim { get; set; }

        public virtual byte [] foto { get; set; }

        public virtual fio fio { get; set; }

        public virtual sl_firm firma { get; set; }

        public Foto()
        {
        }

        public Foto(int idFoto, int fio, int firma, DateTime data, string prim, byte[] foto)
        {
            id_foto = idFoto;
            this.fio.id = fio;
            this.firma.id = firma;
            Data = data;
            this.prim = prim;
            this.foto = foto;
        }
    }
}
