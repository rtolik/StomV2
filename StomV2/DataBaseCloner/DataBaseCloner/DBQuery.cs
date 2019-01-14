using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.OldDB;
using NHibernate;

namespace DataBaseCloner
{
    public  class DBQuery 
    {
        private readonly ISession session;

        public DBQuery(ISession session)
        {
            this.session = session;
        }

        public List<T> FindAll<T>() where T : class
        {
            return (List<T>)session.CreateCriteria<T>().List<T>();
        }

        public  T FindOne<T>( int id) where T : class
        {
            return session.Get<T>(id);
        }

        public void Save<T>(List<T> objects) where T : class,DataBaseCloner.NewDB.Interfaces.IEntityble
        {
            foreach (T obj in objects)
            {
                if (obj.Id != null)
                    session.Save(obj, obj.Id);
                else
                    session.Save(obj);
            }
        }
    }
}
