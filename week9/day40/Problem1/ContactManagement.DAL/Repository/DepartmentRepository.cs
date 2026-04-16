using ContactManagementSystem.Db;
using ContactManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagementSystem.Repository
{
    public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments.Include(c=>c.ContactInfos).ToListAsync();
    }

    public async Task<Department> AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return department;
    }
}
}