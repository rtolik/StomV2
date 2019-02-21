using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
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

        public Paragraph(sl_op_roz roz)
        {
            Id = roz.id_roz;
            Name = roz.n_roz;
            Printable = roz.druk;
        }
    }
}
