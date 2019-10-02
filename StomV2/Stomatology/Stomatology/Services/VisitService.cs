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
    class VisitService : BaseService<VisitRepository>
    {
        public VisitService(ISession session) : base(session){}

        public List<Visit> FindAll()
        {
            List<Visit> visits;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new VisitRepository(Session);
                visits = Repository.FindAll<Visit>();
                transaction.Commit();
            }


            return visits;
        }

        public List<Visit> FindAllByPatientAndRange(Patient patient, DateTime left, DateTime right, VisitCategory visitCategory)
        {
            return FindAll()
                .Where(visit => visit.Patient.Id.Equals(patient.Id))
                .Where(visit => visit.Date >= left && visit.Date <= right)
                .Where(visit => visit.VisitCategory.Id.Equals(visitCategory.Id))
                .ToList();
        }
    }
}
