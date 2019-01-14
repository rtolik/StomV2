using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    public class Operation : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual int Number { get; set; }

        public virtual float Sale { get; set; }

        public virtual float Summ { get; set; }

        public virtual bool IsMade { get; set; }

        public virtual Manipulation Manipulation { get; set; }

        public virtual Visit Visit { get; set; }

        public Operation()
        {
            Id = null;
        }

        public Operation(int visitId, int manipulationId, int number,
            float sale, float summ, bool isMade)
        {
            Id = null;
            Visit.Id = visitId;
            Manipulation.Id = manipulationId;
            Number = number;
            Sale = sale;
            Summ = summ;
            IsMade = isMade;
        }

        public Operation(oper oper, Manipulation manipulation, Visit visit)
        {
            Id = null;
            Number = oper.kol;
            Sale = oper.sale;
            Summ = oper.suma;
            IsMade = true;
            Manipulation = manipulation;
            Visit = visit;
        }

        public Operation(pl_oper oper, Manipulation manipulation, Visit visit)
        {
            Id = null;
            Number = oper.kol;
            Sale = oper.sale;
            Summ = oper.suma;
            IsMade = false;
            Manipulation = manipulation;
            Visit = visit;
        }
    }
}
