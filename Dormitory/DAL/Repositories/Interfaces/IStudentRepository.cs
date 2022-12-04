using DormitoryApi.DAL.Models;

namespace DormitoryApi.DAL.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<Student> DeleteAsync(int studentId);
        //one method takes one student, the other takes a list of students
        Task<Student> GetAsync(int studentId);
        Task<List<Student>> GetAsync();
        Task<bool> ExistAsync(string name, string surname);
    }
}
