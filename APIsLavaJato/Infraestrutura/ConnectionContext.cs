using Microsoft.EntityFrameworkCore;
using APIsNET.Domain.Model;

namespace APIsNET.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5433;Database=postgres;" +
            "User Id=postgres;" +
            "Password=1234;");
    }
}
