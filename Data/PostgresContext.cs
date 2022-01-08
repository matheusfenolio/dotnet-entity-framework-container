using Microsoft.EntityFrameworkCore;
using dotnet_six.Models;

namespace dotnet_six.Data {
    public class PostgresContext : DbContext {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) {}
        public DbSet<User> User { get;set; } 
    }
}