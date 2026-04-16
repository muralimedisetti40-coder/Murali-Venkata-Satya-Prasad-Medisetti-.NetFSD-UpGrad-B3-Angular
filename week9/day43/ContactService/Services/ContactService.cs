using ContactService.Models;
using ContactService.Repositories;

namespace ContactServices.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(Contact contact)
        {
            await _repo.AddAsync(contact);
        }

        public async Task UpdateAsync(int id, Contact contact)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return;

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
            existing.CategoryId = contact.CategoryId;

            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}