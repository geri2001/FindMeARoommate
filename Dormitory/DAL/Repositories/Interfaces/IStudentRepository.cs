using DormitoryApi.DAL.Models;

namespace DormitoryApi.DAL.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);
        Task<Student> UpdateAsync(string name, string surname);
        Task<Student> DeleteAsync(int studentId);

        Task<Student> GetAsync(int studentId);
        Task<List<Student>> GetAsync();
    }
}
