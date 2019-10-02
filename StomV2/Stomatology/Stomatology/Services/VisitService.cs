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
        private DoctorService _doctorService;

        private VisitCategoryService _visitCategoryService;

        public VisitService(ISessionFactory session) : base(session)
        {
            _doctorService = new DoctorService(session);
            _visitCategoryService = new VisitCategoryService(session);
        }

        public List<Visit> FindAll()
        {
            List<Visit> visits;
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    Repository = new VisitRepository(mysqlSession);
                    visits = Repository.FindAll<Visit>();
                    transaction.Commit();
                }
            }

            return visits;
        }

        public List<Visit> FindAllByPatientAndRange(Patient patient, DateTime left, DateTime right, VisitCategory visitCategory)
        {
            List<Visit> visits = FindAll()
                .Where(visit => visit.Patient.Id.Equals(patient.Id))
                .Where(visit => visit.Date >= left && visit.Date <= right)
                .Where(visit => visit.VisitCategory.Id.Equals(visitCategory.Id))
                .ToList();
            visits = AddDoctor(visits);
            visits = AddVisitCategory(visits);

            return visits;
        }

        private List<Visit> AddDoctor(List<Visit> visits)
        {
            for(int i=0; i<visits.Count; i++)
            {
                visits[i].Doctor = _doctorService.FindOne(visits[i].Doctor.Id);
            }

            return visits;
        }

        private List<Visit> AddVisitCategory(List<Visit> visits)
        {
            for (int i = 0; i < visits.Count; i++)
            {
                visits[i].VisitCategory = _visitCategoryService.FindOne(visits[i].Doctor.Id);
            }

            return visits;
        }
    }
}
