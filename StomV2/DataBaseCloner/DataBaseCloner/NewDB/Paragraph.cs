﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    class Paragraph
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual bool Printable { get; set; }

        public Paragraph()
        {
        }

        public Paragraph(int id, string name, bool printable)
        {
            Id = id;
            Name = name;
            Printable = printable;
        }
    }
}
