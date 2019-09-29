using System.Collections.Generic;

namespace Stomatology.Models
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

        public VisitCategory(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
