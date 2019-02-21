using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Stomatology.Models;
using Stomatology.Repository;

namespace Stomatology.Services
{
    class PatientCategoryService:BaseService<PatientCategoryRepository>
    {
        public PatientCategoryService(ISessionFactory session) : base(session){}

        public List<PatientCategory> FindAll()
        {
            List<PatientCategory> categories;
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    Repository = new PatientCategoryRepository(mysqlSession);
                    categories = Repository.FindAll<PatientCategory>();
                    transaction.Commit();
                }
            }
            return categories;
        }
    }
}
