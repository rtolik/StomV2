using System.Collections.Generic;
using System.Linq;
using NHibernate;
using Stomatology.Models;
using Stomatology.Repository;

namespace Stomatology.Services
{
    internal class PatientService : BaseService<PatientRepository>
    {
        private readonly PatientCategoryService _patientCategoryService;

        public PatientService(ISessionFactory session) : base(session)
        {
            _patientCategoryService = new PatientCategoryService(session);
        }


        public List<Patient> MultipleFinder(string cardNumber, string fullName, int firmId, bool archive)
        {
            List<Patient> patients = FindPatientsByArchiveAndFirm(archive, firmId);

            if (cardNumber != "")
                patients = patients.Where(patient => patient.MedicalCard.Contains(cardNumber)).ToList();

            if (fullName != "")
                patients = patients.Where(patient => patient.FullName.Contains(fullName)).ToList();

            return AddCategoriesToPatients(patients);
        }

        public List<Patient> FindPatientsByArchiveAndFirm(bool archive, int firmId)
        {
            return AddCategoriesToPatients(
                FindPatientsByArchive(archive)
                    .Where(patient => patient.Firm.Id == firmId || patient.IsPublic)
                    .ToList()
            );
        }

        public List<Patient> FindPatientsByArchive(bool archive)
        {
            return FindAll()
                .Where(patient => patient.IsArchive.Equals(archive))
                .ToList();
        }

        public List<Patient> FindAll()
        {
            List<Patient> patients;
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    Repository = new PatientRepository(mysqlSession);
                    patients = Repository.FindAll<Patient>();
                    transaction.Commit();
                }
            }

            return patients;
        }

        private List<Patient> AddCategoriesToPatients(List<Patient> patients)
        {
            List<PatientCategory> categories = _patientCategoryService.FindAll();

            for (int i = 0; i < patients.Count; i++)
                patients[i].PatientCategory = categories.Find(cat => cat.Id == patients[i].PatientCategory.Id);

            return patients;
        }
    }
}