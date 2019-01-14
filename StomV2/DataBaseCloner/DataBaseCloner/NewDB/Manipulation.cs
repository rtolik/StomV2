using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{ 
    public class Manipulation : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual float Price { get; set; }

        public virtual ISet<Operation> Operations { get; set; }

        public virtual ISet<Matherial> Matherials { get; set; }

        public virtual Paragraph Paragraph { get; set; }

        public Manipulation()
        {
            Id = null;
        }

        public Manipulation(string name, float price, int paragraphId)
        {
            Id = null;
            Name = name;
            Price = price;
            Paragraph.Id = paragraphId;
        }

        public Manipulation(sl_op_op op, Paragraph paragraph)
        {
            Id = op.id_op;
            Name = op.n_op;
            Price = op.cena;
            Paragraph = paragraph;
        }
    }
}
