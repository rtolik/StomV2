using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Stomatology.Repository
{
    public class VisitCategoryRepository : BaseRepository
    {
        public VisitCategoryRepository(ISession session) : base(session) { }
    }
}
