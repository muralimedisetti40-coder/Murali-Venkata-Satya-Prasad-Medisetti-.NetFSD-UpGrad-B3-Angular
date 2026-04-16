namespace ContactManagementSystem.Models
{
    public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ContactInfo> ContactInfos { get; set; }
}
}