using DormitoryApi.BLL.Services.Interface;
using DormitoryApi.DAL.Models;
using DormitoryApi.DAL.Repositories.Implementation;
using DormitoryApi.DAL.Repositories.Interfaces;
using System.Xml.Linq;

namespace DormitoryApi.BLL.Services.Implementation
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)

        {
            _applicationRepository = applicationRepository;
        }

        public async Task<Application> AddAsync(int AnnouncementID, int StudentID)
        {
            if (!await _applicationRepository.ExistAsync(AnnouncementID, StudentID))
            {
                throw new Exception("Annuncement ID or Student ID does not exist");
            }
            var result = new Application
            {
                AnnouncementId = AnnouncementID,
                StudentId = StudentID,
                ApplicationDate = DateTime.Now,
                IsActive = true,
            };
            return result;

        }

    }
}
