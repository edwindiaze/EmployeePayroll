using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeePayroll.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.Property(e => e.FirstName).HasMaxLength(20).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(30).IsRequired();
        builder.Ignore(e => e.FullName);
        
        builder.Property(e => e.Age).IsRequired();
        builder.Property(e => e.WorkedHours).IsRequired();
        builder.Property(e => e.SalaryByHours).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(e => e.EmployeeType).IsRequired().HasConversion(
            v => v.ToString(),
            v => (EmployeeTypes)Enum.Parse(typeof(EmployeeTypes), v)
        );
        
        builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Email).IsUnique();

        builder.HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired();

        // Add other configuration rules as needed
    }
}
