using Microsoft.AspNetCore.Mvc;
using ContactManagementSystem.Models;
using ContactManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using ContactManagementSystem.Dto;
namespace ContactManagementSystem.Controllers
{
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _repo;

    public ContactsController(IContactRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repo.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _repo.GetByIdAsync(id);
        if (data == null) return NotFound();
        return Ok(data);
    }

    [HttpPost]
[Authorize(Roles = "Admin")]
public async Task<IActionResult> Create(ContactDto dto)
{
    var contact = new ContactInfo
    {
        Name = dto.Name,
        Email = dto.Email,
        CompanyId = dto.CompanyId,
        DepartmentId = dto.DepartmentId
    };

    await _repo.AddAsync(contact);

    return Created("", contact);
}

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, ContactInfo contact)
    {
        if (id != contact.Id) return BadRequest();

        await _repo.UpdateAsync(contact);
        return Ok(contact);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return Ok();
    }
}
    }
