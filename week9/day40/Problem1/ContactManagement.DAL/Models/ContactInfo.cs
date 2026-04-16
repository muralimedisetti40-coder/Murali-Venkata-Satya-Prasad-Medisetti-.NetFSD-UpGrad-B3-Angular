using System.ComponentModel.DataAnnotations.Schema;
namespace ContactManagementSystem.Models{
public class ContactInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    // FK
    public int CompanyId { get; set; }
    public int DepartmentId { get; set; }

    // Navigation
    public Company? Company { get; set; }
    public Department? Department { get; set; }
}
}