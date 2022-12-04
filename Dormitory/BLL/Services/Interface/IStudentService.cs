using DormitoryApi.DAL.Models;

namespace DormitoryApi.BLL.Services.Interface;

public interface IStudentService
{
    Task<Student> AddAsync(string name, string surname);
    Task<Student> GetAllAsync();
}
