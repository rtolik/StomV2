using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Net.Mime;
using System.Drawing;

namespace DataBaseCloner.OldDB
{
    public class fio
    {
        public virtual int id { get; set; }

        public virtual int? nomer { get; set; }

        public virtual DateTime datar { get; set; }

        public virtual string fio_name { get; set; } 

        public virtual string tel1 { get; set; }

        public virtual string tel2 { get; set; }

        public virtual string adres { get; set; }

        public virtual int? sales { get; set; }

        public virtual string prim { get; set; }

        public virtual string proti { get; set; }

        public virtual byte [] foto { get; set; } 

        public virtual float? n1 { get; set; }

        public virtual float? n2 { get; set; }

        public virtual float? n3 { get; set; }

        public virtual bool? zagal { get; set; }

        public virtual sl_cat cat { get; set; }

        public virtual ISet<pl_pr> pl_prs { get; set; }

        public virtual ISet<priom> prioms { get; set; }

        public virtual ISet<Foto> fotos { get; set; }

        public virtual ISet<gotivka> gotivkas { get; set; }


        public fio()
        {
        }

        public fio(int id, int nomer, DateTime datar, string fioName, string tel1,
                   string tel2, string adres, int sales, string prim, string proti,
                   byte[] foto, float n1, float n2, float n3, bool zagal, int caiId)
        {
            this.id = id;
            this.nomer = nomer;
            this.datar = datar;
            fio_name = fioName;
            this.tel1 = tel1;
            this.tel2 = tel2;
            this.adres = adres;
            this.sales = sales;
            this.prim = prim;
            this.proti = proti;
            this.foto = foto;
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
            this.zagal = zagal;
            this.cat.id_cat = caiId;
        }
    }
}