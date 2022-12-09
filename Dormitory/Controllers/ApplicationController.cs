using DormitoryApi.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DormitoryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }
    // GET: api/<ApplicationController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<ApplicationController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ApplicationController>
    [HttpPost("Create")]
    public async Task<IActionResult> Create(int AnnouncementID, int StudentID)
    {

        var createdApplication = await _applicationService.AddAsync(AnnouncementID, StudentID);

        return Ok(createdApplication);

    }

    // PUT api/<ApplicationController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ApplicationController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
