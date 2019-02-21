using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Stomatology.Repository
{
    class PhotoRepository:BaseRepository
    {
        public PhotoRepository(ISession session) : base(session){}
    }
}
