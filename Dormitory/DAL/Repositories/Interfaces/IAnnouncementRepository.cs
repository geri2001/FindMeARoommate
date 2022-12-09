using DormitoryApi.DAL.Models;

namespace DormitoryApi.DAL.Repositories.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<Announcement> AddAsync(Announcement announcement);
        Task<List<Announcement>> GetAsync();
        //Task<Announcement> GetAsync(int dormitoryId);
        Task<bool> Exists(int id);
        //Task Disable(int id);
    }
}
