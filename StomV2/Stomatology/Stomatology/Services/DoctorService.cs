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
        public DoctorService(ISessionFactory session) : base(session)
        {
        }

        public List<Doctor> FindAll()
        {
            List<Doctor> doctors;
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    Repository = new DoctorRepository(mysqlSession);
                    doctors = Repository.FindAll<Doctor>();
                    transaction.Commit();
                }
            }
            return doctors;
        }

        public Doctor FindOne(int? id)
        {
            Doctor doctor = null;
            if (id != null)
            {
                using (ISession mysqlSession = session.OpenSession())
                {
                    using (ITransaction transaction = mysqlSession.BeginTransaction())
                    {
                        Repository = new DoctorRepository(mysqlSession);
                        doctor = Repository.FindOne<Doctor>((int)id);
                        transaction.Commit();
                    }
                }
            }
            return doctor;
        }

    }
}
