using DormitoryApi.DAL.Models;

namespace DormitoryApi.DAL.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task<Application> AddAsync(Application application);
        Task<bool> ExistAsync(int AnnouncementID, int StudentID);
    }
}
