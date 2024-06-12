using EmployeePayroll.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeePayroll.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FirstName).HasMaxLength(20).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(30).IsRequired();
        builder.OwnsOne(e => e.FullName, fullName =>
        {
            fullName.Property(fn => fn.Value)
                .HasColumnName("FullName")
                .HasMaxLength(50)
                .IsRequired();
        });
        builder.Property(e => e.Age).IsRequired();
        builder.Property(e => e.WorkedHours).IsRequired();
        builder.Property(e => e.SalaryByHour).IsRequired();
        builder.Property(e => e.EmployeeType).IsRequired();
        builder.Property(e => e.Email).IsRequired();
        builder.HasIndex(e => e.Email).IsUnique();
        builder.HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired();

        // Add other configuration rules as needed
    }
}
