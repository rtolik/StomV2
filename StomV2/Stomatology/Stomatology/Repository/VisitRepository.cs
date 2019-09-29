using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Stomatology.Repository
{
    class VisitRepository : BaseRepository
    {
        public VisitRepository(ISession session) : base(session) { }

    }
}
