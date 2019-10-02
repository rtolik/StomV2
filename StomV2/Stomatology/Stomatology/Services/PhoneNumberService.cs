using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Mapping;
using Stomatology.Models;
using Stomatology.Repository;

namespace Stomatology.Services
{
    public class PhoneNumberService : BaseService<PhoneNumberRepository>
    {
        public PhoneNumberService(ISession session) : base(session)
        {
        }

        public List<Patient> AddPhoneNumbersToPatients(List<Patient> patients)
        {
            List<PhoneNumber> phone = FindAll();
            foreach (Patient patient in patients)
            {
                if (phone != null)
                    patient.PhoneNumbers =
                        phone.Where(phoneNumber => phoneNumber.Patient.Id == patient.Id).ToList();
            }
            return patients;
        }

        public Patient AddPhoneNumbersToOnePatient(Patient patient)
        {
            List<PhoneNumber> phones = FindAll().Where(number => number.Patient.Id == patient.Id).ToList();

            patient.PhoneNumbers = phones;

            return patient;
        }

        public List<PhoneNumber> FindAll()
        {
            List<PhoneNumber> phoneNumbers;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new PhoneNumberRepository(Session);
                phoneNumbers = Repository.FindAll<PhoneNumber>();
                transaction.Commit();
            }
            return phoneNumbers;
        }
    }
}
