using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    public class VisitCategory
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ISet<Visit> Visits { get; set; }

        public VisitCategory()
        {
        }

        public VisitCategory(string name)
        {
            Name = name;
        }
    }
}
