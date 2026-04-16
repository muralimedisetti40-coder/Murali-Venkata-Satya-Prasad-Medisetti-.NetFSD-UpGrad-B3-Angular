using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly JwtService _jwt;

    public AuthController(ApplicationDbContext context, JwtService jwt)
    {
        _context = context;
        _jwt = jwt;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userExists = await _context.Users
            .AnyAsync(u => u.EmailId == dto.EmailId);

        if (userExists)
            return BadRequest("User already exists");

        var user = new UserInfo
        {
            EmailId = dto.EmailId,
            Password = dto.Password,
            Role = dto.Role
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return Ok("User Registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.EmailId == dto.EmailId && u.Password == dto.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = await _jwt.GenerateTokenAsync(user);

        return Ok(new { Token = token });
    }
}
