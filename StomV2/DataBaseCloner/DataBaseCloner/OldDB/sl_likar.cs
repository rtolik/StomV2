using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.OldDB
{
    class sl_likar
    {
        public virtual int id_likar { get; set; }

        public virtual string n_likar { get; set; }

        public sl_likar()
        {
        }

        public sl_likar(int id_likar, string n_likar)
        {
            this.id_likar = id_likar;
            this.n_likar = n_likar;
        }
    }
}
