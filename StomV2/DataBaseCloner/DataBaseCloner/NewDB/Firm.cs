using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
{
    class Firm
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

        public virtual bool IsPatientPublic { get; set; }

        public Firm()
        {
        }

        public Firm(int id, string name, string code, bool ssPatientPublic)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.IsPatientPublic = ssPatientPublic;
        }
    }
}
