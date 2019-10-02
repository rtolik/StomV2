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
        public FirmService(ISession session) : base(session) { }

        public List<PatientCategory> FindAll()
        {
            List<PatientCategory> categories;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new FirmRepository(Session);
                categories = Repository.FindAll<PatientCategory>();
                transaction.Commit();
            }
            return categories;
        }

        public Firm FindOne(int firmId)
        {
            Firm firm;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new FirmRepository(Session);
                firm = Repository.FindOne<Firm>(firmId);
                transaction.Commit();
            }

            return firm;
        }
    }
}
