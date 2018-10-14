using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    class VisitCategory
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public VisitCategory()
        {
        }

        public VisitCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
