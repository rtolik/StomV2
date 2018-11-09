using System.Collections.Generic;

namespace DataBaseCloner.OldDB
{
    public class sl_cat
    {
        public virtual int id_cat { get; set; }

        public virtual string n_cat { get; set; }

        public virtual ISet<fio> fios { get; set; }

        public sl_cat()
        {
        }

        public sl_cat(int idCat, string nCat, ISet<fio> fios)
        {
            id_cat = idCat;
            n_cat = nCat;
            this.fios = fios;
        }
    }
}