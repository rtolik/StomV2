using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Stomatology.Repository
{
    class PatientRepository:BaseRepository
    {
        public PatientRepository(ISession session) : base(session){}


    }
}
