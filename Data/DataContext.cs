using Cqrs.Models;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { } 
        

        public DbSet<Employee> Employees { get; set; }
    }
}
