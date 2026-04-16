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
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _repo;

    public CompanyController(ICompanyRepository repo)
    {
        _repo = repo;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _repo.GetAllAsync();
        return Ok(data);
    }

    // CREATE (Admin only)
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CompanyDto companyDto)
    {
        var Company = new Company
    {
        Name = companyDto.Name,
    };
        var result = await _repo.AddAsync(Company);
        return Created("", result);
    }
}
}