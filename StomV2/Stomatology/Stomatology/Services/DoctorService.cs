using NHibernate;
using Stomatology.Models;
using Stomatology.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Services
{
    public class DoctorService : BaseService<DoctorRepository>
    {
        public DoctorService(ISession session) : base(session)
        {
        }

        public List<Doctor> FindAll()
        {
            List<Doctor> doctors;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new DoctorRepository(Session);
                doctors = Repository.FindAll<Doctor>();
                transaction.Commit();
            }
            return doctors;
        }

        public Doctor FindOne(int? id)
        {
            Doctor doctor = null;
            if (id != null)
            {
                using (ITransaction transaction = Session.BeginTransaction())
                {
                    Repository = new DoctorRepository(Session);
                    doctor = Repository.FindOne<Doctor>((int)id);
                    transaction.Commit();
                }
            }
            return doctor;
        }

    }
}
