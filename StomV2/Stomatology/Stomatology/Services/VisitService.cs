using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Stomatology.Repository;

namespace Stomatology.Services
{
    class VisitService : BaseService<VisitRepository>
    {
        public VisitService(ISessionFactory session) : base(session) { }


    }
}
