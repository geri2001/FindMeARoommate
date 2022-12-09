using DormitoryApi.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DormitoryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementController : ControllerBase

{

    private readonly IAnnouncementService _announcementService;

    public AnnouncementController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService ?? throw new ArgumentNullException(nameof(announcementService));
    }

    // GET: api/<ValuesController>
    [HttpGet("Read")]
    public async Task<IActionResult> Get()
    {
        var result = await _announcementService.GetAll();
        return Ok(result);
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ValuesController>
    [HttpPost("Create")]
    public async Task<IActionResult> Create(string title, string description)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
        {
            return BadRequest("Please provide all information for Announcement");
        }

        var createdAnnouncement = await _announcementService.AddAsync(title, description);

        return Ok(createdAnnouncement);

    }
}


