using NHibernate;
using Stomatology.Models;
using Stomatology.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stomatology.Services
{
    class PhotoService : BaseService<PhotoRepository>
    {

        private readonly PatientService _patientService;
        public PhotoService(ISessionFactory session) : base(session)
        {
            _patientService = new PatientService(session); 
        }

        public List<Photo> FindAllByPatientIdAndDateRange(int patientId, DateTime from, DateTime to)
        {
            List<Photo> photos;
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    Repository = new PhotoRepository(mysqlSession);
                    photos = Repository.FindAll<Photo>()
                        .Where(photo => photo.Patient.Id == patientId)
                        .Where(photo => photo.Date >=  from && photo.Date <= to)
                        .ToList();
                    transaction.Commit();
                }
            }

            return AddPatientsToPhotos(photos);
        }

        public void Save(Photo photo)
        {
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    try
                    {
                        Repository = new PhotoRepository(mysqlSession);
                        Repository.Save(photo);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.StackTrace);
                        throw;
                    }
                    transaction.Commit();
                }
            }
        }

        public void Update(Photo photo)
        {
            using (ISession mysqlSession = session.OpenSession())
            {
                using (ITransaction transaction = mysqlSession.BeginTransaction())
                {
                    try
                    {
                        Repository = new PhotoRepository(mysqlSession);
                        Repository.Update(photo);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.StackTrace);
                        throw;
                    }
                    transaction.Commit();
                }
            }
        }

        private List<Photo> AddPatientsToPhotos(List<Photo> photos)
        {
            photos.ForEach(photo => photo.Patient = _patientService.FindOne(photo.Patient.Id.Value));
            return photos;
        }
    }
}
