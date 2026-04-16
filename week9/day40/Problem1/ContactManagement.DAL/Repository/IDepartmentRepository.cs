using ContactManagementSystem.Models;
namespace ContactManagementSystem.Repository{
public interface IDepartmentRepository
{
    Task<List<Department>> GetAllAsync();
    Task<Department> AddAsync(Department department);
}
}