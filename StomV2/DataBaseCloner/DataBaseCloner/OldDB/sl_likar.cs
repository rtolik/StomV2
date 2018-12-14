using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    public class sl_likar
    {
        public virtual int id_likar { get; set; }

        public virtual string n_likar { get; set; }

        public virtual ISet<pl_pr> pl_prs { get; set; }

        public virtual ISet<priom> prioms { get; set; }


        public sl_likar()
        {
        }

        public sl_likar(int idLikar, string nLikar)
        {
            id_likar = idLikar;
            n_likar = nLikar;
        }
    }
}
