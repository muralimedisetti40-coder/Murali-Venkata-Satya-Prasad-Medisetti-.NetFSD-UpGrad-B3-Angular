using ContactManagementSystem.Db;
using ContactManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace ContactManagementSystem.Repository
{
    public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Company>> GetAllAsync()
{
    return await _context.Companies
        .Include(c => c.ContactInfos)
        .ToListAsync();
}
    public async Task<Company> AddAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
        return company;
    }
}
}