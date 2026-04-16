using Microsoft.AspNetCore.Mvc;
using ContactServices.Services;
using ContactService.Models;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _service.GetByIdAsync(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            await _service.AddAsync(contact);
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Contact contact)
        {
            await _service.UpdateAsync(id, contact);
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}