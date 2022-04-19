using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;
public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Log> Logs { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
