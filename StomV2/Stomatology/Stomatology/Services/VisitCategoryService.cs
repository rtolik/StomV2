using NHibernate;
using Stomatology.Models;
using Stomatology.Repository;
using System.Collections.Generic;

namespace Stomatology.Services
{
    public class VisitCategoryService : BaseService<VisitCategoryRepository>
    {
        public VisitCategoryService(ISessionFactory session) : base(session)
        {
        }

        public List<VisitCategory> FindAll()
        {
            List<VisitCategory> categories;
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    Repository = new VisitCategoryRepository(mysqlSession);
                    categories = Repository.FindAll<VisitCategory>();
                    transaction.Commit();
                }
            }
            return categories;
        }
    }
}
