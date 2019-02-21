using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Stomatology.Repository;

namespace Stomatology.Services
{
    public class BaseService<T> where T:BaseRepository
    {
        protected T Repository;

        protected readonly ISessionFactory session;

        public BaseService(ISessionFactory session)
        {
            this.session = session;
            
        }
    }
}
