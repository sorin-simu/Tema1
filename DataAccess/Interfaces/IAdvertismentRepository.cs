using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IAdvertismentRepository
    {
        void CreateAdvertisment(Advertisment advertisment);
        void DeleteAdvertisment(int advertismentId);
        void EditAdvertisment(Advertisment advertisment);
        List<Advertisment> GetAllAdvertisments();
        List<Advertisment> GetAdvertismentByUserId(int userId);
        Advertisment GetAdvertismentByTitle(string title);
    }
}
