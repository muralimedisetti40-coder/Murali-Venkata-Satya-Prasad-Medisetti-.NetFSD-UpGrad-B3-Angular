using Microsoft.EntityFrameworkCore;
using ContactManagementSystem.Models;
namespace ContactManagementSystem.Db{
public class ApplicationDbContext : DbContext
{
 public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
 : base(options)
 {
 }
 public DbSet<ContactInfo> ContactInfos { get; set; }
public DbSet<Company> Companies { get; set; }
public DbSet<Department> Departments { get; set; }
public DbSet<User> Users { get; set; }
 protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInfo>()
                        .HasOne(e => e.Company)
                        .WithMany(d => d.ContactInfos)
                        .HasForeignKey(e => e.CompanyId);
            modelBuilder.Entity<ContactInfo>()
                        .HasOne(e => e.Department)
                        .WithMany(d => d.ContactInfos)
                        .HasForeignKey(e => e.DepartmentId);
        }
}
}