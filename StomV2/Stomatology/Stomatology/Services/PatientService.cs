using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;
using NHibernate;
using Stomatology.Models;
using Stomatology.Repository;

namespace Stomatology.Services
{
    internal class PatientService : BaseService<PatientRepository>
    {
        public PatientService(ISession session) : base(session){}

        public List<Patient> FindAll()
        {
            List<Patient> patients;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new PatientRepository(Session);
                patients = Repository.FindAll<Patient>();
                transaction.Commit();
            }
            return patients;
        }

        public Patient FindOne(int id)
        {
            Patient patient;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new PatientRepository(Session);
                patient = Repository.FindOne<Patient>(id);
                transaction.Commit();
            }

            return patient;
        }

        public void Save(Patient patient)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    Repository = new PatientRepository(Session);
                    Repository.Save(patient);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace);
                    throw;
                }
                transaction.Commit();
            }
        }

        public void Save(List<Patient> patients)
        {
            foreach (Patient patient in patients)
                Save(patient);
        }

        public void Update(Patient patient)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    Repository = new PatientRepository(Session);
                    Repository.Update(patient);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace);
                    throw;
                }
                transaction.Commit();
            }
        }

        public void Update(List<Patient> patients)
        {
            foreach (Patient patient in patients)
                Update(patient);
        }

        public List<Patient> MultipleFinder(string cardNumber, string fullName, int firmId, bool archive)
        {
            List<Patient> patients = FindPatientsByArchiveAndFirm(archive, firmId);

            if (cardNumber != "")
                patients = patients.Where(patient => patient.MedicalCard.Contains(cardNumber)).ToList();

            if (fullName != "")
                patients = patients.Where(patient => patient.FullName.Contains(fullName)).ToList();

            return patients;
        }

        public List<Patient> FindPatientsByArchiveAndFirm(bool archive, int firmId)
        {
            return 
                FindPatientsByArchive(archive)
                    .Where(patient => patient.Firm.Id == firmId || patient.IsPublic)
                    .ToList();
        }

        public List<Patient> FindPatientsByArchive(bool archive)
        {
            return FindAll()
                .Where(patient => patient.IsArchive.Equals(archive))
                .ToList();
        }
    }
}