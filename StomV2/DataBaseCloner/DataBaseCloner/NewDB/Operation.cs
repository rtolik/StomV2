using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCloner.NewDB
{
    public class Operation
    {
        public virtual int Id { get; set; }

        public virtual int Number { get; set; }

        public virtual float Sale { get; set; }

        public virtual float Summ { get; set; }

        public virtual bool IsMade { get; set; }

        public virtual Manipulation Manipulation { get; set; }

        public virtual Visit Visit { get; set; }

        public Operation()
        {
        }

        public Operation(int id, int visitId, int manipulationId, int number,
            float sale, float summ, bool isMade)
        {
            Id = id;
            Visit.Id = visitId;
            Manipulation.Id = manipulationId;
            Number = number;
            Sale = sale;
            Summ = summ;
            IsMade = isMade;
        }
    }
}
