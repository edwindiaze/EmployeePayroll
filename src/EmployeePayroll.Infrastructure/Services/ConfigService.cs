using Microsoft.Extensions.Configuration;

namespace EmployeePayroll.Infrastructure.Services
{
    public static class ConfigService
    {
        public static string? GetConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
            }

            return connectionString;
        }
    }
}
