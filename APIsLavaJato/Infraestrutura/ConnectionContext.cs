using APIsNET.Domain.Model.CompanyAggregate;
using APIsNET.Domain.Model.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace APIsNET.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5433;Database=postgres;" +
            "User Id=postgres;" +
            "Password=1234;");
    }
}
