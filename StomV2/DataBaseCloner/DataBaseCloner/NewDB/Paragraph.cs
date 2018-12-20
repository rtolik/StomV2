using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    public class Paragraph
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual bool Printable { get; set; }

        public virtual ISet<Manipulation> Manipulations { get; set; }

        public Paragraph()
        {
        }

        public Paragraph(string name, bool printable)
        {
            Name = name;
            Printable = printable;
        }
    }
}
