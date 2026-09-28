using Microsoft.EntityFrameworkCore;
using Recevita.Domain.Entities;

namespace Recevita.Infrastructure.DataAccess;

internal class RecevitaDbContext : DbContext
{
    public RecevitaDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
