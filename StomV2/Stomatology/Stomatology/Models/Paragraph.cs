using System.Collections.Generic;

namespace Stomatology.Models
{
    public class Paragraph : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual bool Printable { get; set; }

        public virtual ISet<Manipulation> Manipulations { get; set; }

        public Paragraph()
        {
            Id = null;
        }

        public Paragraph(string name, bool printable)
        {
            Id = null;
            Name = name;
            Printable = printable;
        }
    }
}
