using Microsoft.EntityFrameworkCore;

namespace VMT.CineHub.Persistence.Database;
public sealed class CineHubDbContext(DbContextOptions db) : DbContext(db)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CineHubDbContext).Assembly);
}