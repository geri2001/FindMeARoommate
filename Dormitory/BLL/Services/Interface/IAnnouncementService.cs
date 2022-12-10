using DormitoryApi.DAL.Models;

namespace DormitoryApi.BLL.Services.Interface
{
    public interface IAnnouncementService
    {
        Task<Announcement> AddAsync(string title, string description);
        Task<List<Announcement>> GetAll();
        // Task Disable(int id);
    }
}