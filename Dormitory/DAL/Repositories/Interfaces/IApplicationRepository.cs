using DormitoryApi.DAL.Models;

namespace DormitoryApi.DAL.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        //Task<Application> AddAsync(int AnnouncementID, int StudentID);
        Task<bool> ExistAsync(int AnnouncementID, int StudentID);
    }
}
