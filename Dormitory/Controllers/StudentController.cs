using DormitoryApi.BLL.Services.Interface;
using DormitoryApi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DormitoryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
    }
    [HttpPost("create")]
    public async Task<IActionResult> Create(string name, string surname)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
        {
            return BadRequest("Please provide all info for student!");
        }
        var createdStudent= await _studentService.AddAsync(name, surname);
        return Ok(createdStudent);
    }

    [HttpGet("read")]
    public async Task<List<Student>> GetAsync()
    {
        var result = await _studentService.GetAllAsync();
        return result;
    }
}

