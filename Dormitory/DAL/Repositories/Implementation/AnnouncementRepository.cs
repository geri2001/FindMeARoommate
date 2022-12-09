using Microsoft.EntityFrameworkCore;
using DormitoryApi.DAL.Context;
using DormitoryApi.DAL.Models;
using DormitoryApi.DAL.Repositories.Interfaces;

namespace Dormitories.DAL.Repositories.Implementation;


public class AnnouncementRepository : IAnnouncementRepository
{
    private readonly DormitoryContext _context;
    public AnnouncementRepository(DormitoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Announcement> AddAsync(Announcement announcement)
    {
        var result = _context.Announcements.Add(announcement);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<List<Announcement>> GetAsync()
    {
        var result = await _context.Announcements.Where(a => a.IsActive == true).ToListAsync();
        return result;
    }

    public async Task<bool> Exists(int id)
    {
        var result = await _context.Announcements.AnyAsync(a => a.Id == id);
        return result;
    }
    //public async Task Disable(int id)
    //{
    //    var result =  _context.Announcements.FirstOrDefault(a => a.Id == id && a.IsActive == true);
    //    result.IsActive = false;
    //    _context.SaveChanges();
    //}
}

