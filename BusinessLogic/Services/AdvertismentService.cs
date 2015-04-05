using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repository;

namespace BusinessLogic.Services
{
    public class AdvertismentService : IAdvertismentService
    {
        private readonly IAdvertismentRepository _advertismentRepository;

        public AdvertismentService()
        {
            _advertismentRepository = new AdvertismentRepository();
        }

        public void CreateAdvertisment(Advertisment newAdvertisment)
        {
           _advertismentRepository.CreateAdvertisment(newAdvertisment);
        }

        public int GetNumberOfAdvertismentsPerUser(int userId)
        {
            return _advertismentRepository.GetAdvertismentByUserId(userId).Count;
        }

        public void DeleteAdvertisment(int advertismentId)
        {
            _advertismentRepository.DeleteAdvertisment(advertismentId);
        }

        public void EditAdvertisment(Advertisment advertisment)
        {
            _advertismentRepository.EditAdvertisment(advertisment);
        }

        public Advertisment GetAdvertismentByTitle(string title)
        {
            return _advertismentRepository.GetAdvertismentByTitle(title);
        }
    }
}
