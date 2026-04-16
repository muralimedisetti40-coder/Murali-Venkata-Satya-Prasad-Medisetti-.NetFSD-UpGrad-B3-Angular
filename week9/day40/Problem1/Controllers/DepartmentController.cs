using Microsoft.AspNetCore.Mvc;
using ContactManagementSystem.Models;
using ContactManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using ContactManagementSystem.Dto;
using System.Linq.Expressions;
namespace ContactManagementSystem.Controllers
{
    [ApiController]
[Route("api/[controller]")]
[Authorize]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _repo;

    public DepartmentController(IDepartmentRepository repo)
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
    public async Task<IActionResult> Create(DepartmentDto departmentDto)
    {
        var department = new Department{
               Name= departmentDto.Name
            };
        var result = await _repo.AddAsync(department);
        return Created("", result);
    }
}
}