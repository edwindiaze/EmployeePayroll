using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeePayroll.Infrastructure.Persistence.Contexts;

public class InMemoryDbContext(DbContextOptions<PayrollDbContext> options, IConfiguration configuration) 
    : PayrollDbContext(options, configuration)
{
    private readonly IConfiguration _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");
    }
}
