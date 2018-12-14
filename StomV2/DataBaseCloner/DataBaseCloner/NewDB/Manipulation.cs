using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    public class Manipulation
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual float Price { get; set; }

        public virtual ISet<Operation> Operations { get; set; }

        public virtual ISet<Matherial> Matherials { get; set; }

        public virtual Paragraph Paragraph { get; set; }

        public Manipulation()
        {
        }

        public Manipulation(int id, string name, float price, int paragraphId)
        {
            Id = id;
            Name = name;
            Price = price;
            Paragraph.Id = paragraphId;
        }
    }
}
