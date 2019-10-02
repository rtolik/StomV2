using NHibernate;
using Stomatology.Models;
using Stomatology.Repository;
using System.Collections.Generic;

namespace Stomatology.Services
{
    public class VisitCategoryService : BaseService<VisitCategoryRepository>
    {
        public VisitCategoryService(ISession session) : base(session)
        {
        }

        public List<VisitCategory> FindAll()
        {
            List<VisitCategory> categories;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new VisitCategoryRepository(Session);
                categories = Repository.FindAll<VisitCategory>();
                transaction.Commit();
            }

            return categories;
        }

        public VisitCategory FindOne(int? id)
        {
            VisitCategory visitCategory = null;
            if (id != null)
            {
                using (ITransaction transaction = Session.BeginTransaction())
                {
                    Repository = new VisitCategoryRepository(Session);
                    visitCategory = Repository.FindOne<VisitCategory>((int)id);
                    transaction.Commit();
                }
            }
            return visitCategory;
        }
    }
}
