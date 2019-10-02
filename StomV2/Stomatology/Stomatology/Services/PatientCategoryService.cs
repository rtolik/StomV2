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
    class PatientCategoryService : BaseService<PatientCategoryRepository>
    {
        public PatientCategoryService(ISession session) : base(session) { }

        public List<PatientCategory> FindAll()
        {
            List<PatientCategory> categories;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new PatientCategoryRepository(Session);
                categories = Repository.FindAll<PatientCategory>();
                transaction.Commit();
            }
            return categories;
        }
    }
}
