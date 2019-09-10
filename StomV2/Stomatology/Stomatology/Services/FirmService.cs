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
    class FirmService : BaseService<FirmRepository>
    {
        public FirmService(ISessionFactory session) : base(session){}

        public List<PatientCategory> FindAll()
        {
            List<PatientCategory> categories;
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    Repository = new FirmRepository(mysqlSession);
                    categories = Repository.FindAll<PatientCategory>();
                    transaction.Commit();
                }
            }
            return categories;
        }

        public Firm FindOne(int firmId)
        {
            Firm firm;
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    Repository = new FirmRepository(mysqlSession);
                    firm = Repository.FindOne<Firm>(firmId);
                    transaction.Commit();
                }
            }

            return firm;
        }
    }
}
