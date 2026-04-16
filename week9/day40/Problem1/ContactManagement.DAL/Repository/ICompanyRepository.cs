using ContactManagementSystem.Models;
namespace ContactManagementSystem.Repository{
public interface ICompanyRepository
{
    Task<List<Company>> GetAllAsync();
    Task<Company> AddAsync(Company company);
}}