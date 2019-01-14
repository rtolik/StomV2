using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    public class VisitCategory : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ISet<Visit> Visits { get; set; }

        public VisitCategory()
        {
            Id = null;
        }

        public VisitCategory(string name)
        {
            Id = null;
            Name = name;
        }
    }
}
