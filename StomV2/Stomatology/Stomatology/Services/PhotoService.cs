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
        public PhotoService(ISession session) : base(session)
        {
            _patientService = new PatientService(session);
        }

        public List<Photo> FindAllByPatientIdAndDateRange(int patientId, DateTime from, DateTime to)
        {
            List<Photo> photos;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Repository = new PhotoRepository(Session);
                photos = Repository.FindAll<Photo>()
                    .Where(photo => photo.Patient.Id == patientId)
                    .Where(photo => photo.Date >= from && photo.Date <= to)
                    .ToList();
                transaction.Commit();
            }

            return photos;
        }

        public void Save(Photo photo)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    Repository = new PhotoRepository(Session);
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

        public void Update(Photo photo)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    Repository = new PhotoRepository(Session);
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

        private List<Photo> AddPatientsToPhotos(List<Photo> photos)
        {
            photos.ForEach(photo => photo.Patient = _patientService.FindOne(photo.Patient.Id.Value));
            return photos;
        }
    }
}
