using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IAdvertismentService
    {
        void CreateAdvertisment(Advertisment newAdvertisment);
        int GetNumberOfAdvertismentsPerUser(int userId);
        void DeleteAdvertisment(int advertismentId);
        void EditAdvertisment(Advertisment advertisment);
        Advertisment GetAdvertismentByTitle(string title);
    }
}
