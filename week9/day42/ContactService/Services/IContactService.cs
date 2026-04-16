using ContactService.Models;

namespace ContactServices.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact contact);
        Task UpdateAsync(int id, Contact contact);
        Task DeleteAsync(int id);
    }
}