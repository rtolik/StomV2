using System.Collections.Generic;

namespace Stomatology.Models
{ 
    public class Manipulation : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual float Price { get; set; }

        public virtual Paragraph Paragraph { get; set; }

        public virtual ISet<Operation> Operations { get; set; }

        public virtual ISet<Matherial> Matherials { get; set; }

        public Manipulation()
        {
            Id = null;
        }

        public Manipulation(string name, float price, Paragraph paragraph)
        {
            Id = null;
            Name = name;
            Price = price;
            Paragraph = paragraph;
        }
    }
}
