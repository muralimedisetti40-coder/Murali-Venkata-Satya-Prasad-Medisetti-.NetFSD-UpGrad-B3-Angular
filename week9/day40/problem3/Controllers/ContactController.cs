using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _context.Contacts.ToListAsync();
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        return Ok(contact);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Contact contact)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();

        return Ok(contact);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, Contact updated)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        contact.Name = updated.Name;
        contact.Email = updated.Email;
        contact.Phone = updated.Phone;

        await _context.SaveChangesAsync();

        return Ok(contact);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return Ok("Deleted");
    }
}