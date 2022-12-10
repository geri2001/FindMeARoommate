using DormitoryApi.DAL.Models;
using DormitoryApi.DAL.Context;
using DormitoryApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dormitories.DAL.Repositories.Implementation
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DormitoryContext _context;
        public ApplicationRepository(DormitoryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Application> AddAsync(Application application)
        {
            var result = _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //public Task<Application> AddAsync(int AnnouncementID, int StudentID)
        //{
        //    throw new NotImplementedException();

        //}

        public async Task<bool> ExistAsync(int AnnouncementID, int StudentID)
        {
            var result = await _context.Applications.AnyAsync(s => s.StudentId == StudentID && s.AnnouncementId == AnnouncementID);

            return result;
        }
    }
}
