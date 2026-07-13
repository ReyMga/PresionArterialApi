using Microsoft.EntityFrameworkCore;
using PresionArterial.Api.Models;

namespace PresionArterial.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Medicion> Mediciones { get; set; }
}