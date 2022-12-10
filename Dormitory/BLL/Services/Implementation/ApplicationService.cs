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
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IStudentRepository _studentRepository;
        public ApplicationService(IApplicationRepository applicationRepository, IAnnouncementRepository announcementRepository, IStudentRepository studentRepository)

        {
            _applicationRepository = applicationRepository;
            _announcementRepository = announcementRepository;
            _studentRepository = studentRepository;
        }

        public async Task<Application> AddAsync(int AnnouncementID, int StudentID)
        {
            var announcementExist = await _announcementRepository.Exists(AnnouncementID);
            if (!announcementExist)
            {
                throw new Exception("Annuncement does not exist");

            }

            var studentExist = await _studentRepository.Exists(StudentID);
            if (!studentExist)
            {
                throw new Exception("Student ID does not exist");
            }

            var applicationExist = await _applicationRepository.ExistAsync(AnnouncementID, StudentID);
            if(applicationExist)
            {
                throw new Exception("You have already applied for an application!");
            }

            var entity = new Application
            {
                AnnouncementId = AnnouncementID,
                StudentId = StudentID,
                ApplicationDate = DateTime.Now,
                IsActive = true,
            };

            var result = await _applicationRepository.AddAsync(entity);

            return result;

        }

    }
}
