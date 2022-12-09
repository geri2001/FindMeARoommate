using DormitoryApi.DAL.Models;

namespace DormitoryApi.BLL.Services.Interface;

public interface IApplicationService
{
    Task<Application> AddAsync(int AnnouncementID, int StudentID);
}
