using EmployeePayroll.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EmployeePayroll.Infrastructure.Persistence.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Deparments");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name)
            .IsRequired();
        builder.Property(d => d.Address)
            .IsRequired();

        // Add other configuration rules as needed
    }
}
