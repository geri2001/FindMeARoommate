using DormitoryApi.BLL.Services.Interface;
using DormitoryApi.DAL.Models;
using DormitoryApi.DAL.Context;
using DormitoryApi.DAL.Repositories.Implementation;
using DormitoryApi.DAL.Repositories.Interfaces;
​
namespace DormitoryApi.BLL.Services.Implementation;
​
public class AnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementRepository _announcementRepository;
    public AnnouncementService(IAnnouncementRepository announcementRepository)
    {
        _announcementRepository = announcementRepository ?? throw new ArgumentNullException(nameof(announcementRepository));
    }
    public async Task<Announcement> AddAsync(string title, string description)
    {
        if (title == null || description == null)
        {
            throw new InvalidOperationException("Title or Description field cannot be empty");
        }
​
        Announcement announcement = new Announcement
        {
            Title = title,
            Description = description,
            PublishedDate = DateTime.Now,
            IsActive = true
        };
        var result = await _announcementRepository.AddAsync(announcement);
        return result;
    }
    public async Task<List<Announcement>> GetAll()
    {
        var result = await _announcementRepository.GetAsync();
        return result;
    }
    public async Task Disable(int id)
    {
        if (!_announcementRepository.Exists(id))
        {
            throw new InvalidOperationException("Invalid Id");
        }
        await _announcementRepository.Disable(id);
    }
}