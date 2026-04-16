using ContactManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using ContactManagementSystem.Db;
namespace ContactManagementSystem.Repository
{
    public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ContactInfo>> GetAllAsync()
    {
        return await _context.ContactInfos
            .Include(c => c.Company)
            .Include(c => c.Department)
            .ToListAsync();
    }

    public async Task<ContactInfo> GetByIdAsync(int id)
    {
        return await _context.ContactInfos
            .Include(c => c.Company)
            .Include(c => c.Department)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(ContactInfo contact)
    {
        await _context.ContactInfos.AddAsync(contact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ContactInfo contact)
    {
        _context.ContactInfos.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var contact = await _context.ContactInfos.FindAsync(id);
        if (contact != null)
        {
            _context.ContactInfos.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}
}