using DormitoryApi.BLL.Services.Interface;
using DormitoryApi.DAL.Models;
using DormitoryApi.DAL.Repositories.Interfaces;

namespace Dormitories.BLL.Services.Implementation;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
    }

    public async Task<Student> AddAsync(string name, string surname)
    {
        //get info from user, name and surname
        if (await _studentRepository.ExistAsync(name, surname))
        {
            throw new Exception("This user aleady exists!");
        }
        //save user in database
        var student = new Student
        {
            Name = name,
            Surname = surname
        };
        var result = await _studentRepository.AddAsync(student);
        return result;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        var result = await _studentRepository.GetAsync();
        return result;
    }
}