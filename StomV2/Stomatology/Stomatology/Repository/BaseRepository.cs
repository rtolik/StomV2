using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Stomatology.Repository
{
    public class BaseRepository
    {
        protected readonly ISession Session;

        public BaseRepository(ISession session)
        {
            this.Session = session;
        }

        public List<T> FindAll<T>() where T : class
        {
            return (List<T>)Session.CreateCriteria<T>().List<T>();
        }

        public T FindOne<T>(int id) where T : class
        {
            return Session.Get<T>(id);
        }

        public void Save<T>(List<T> objects) where T : class, Models.Interfaces.IEntityble
        {
            foreach (T obj in objects)
            {
                if (obj.Id != null)
                    Session.Save(obj, obj.Id);
                else
                    Session.Save(obj);
            }
        }
    }
}
