using LivroDeReceitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceitas.Infrastructure.DataAccess;

public class LivroDeReceitasDbContext : DbContext
{
    public LivroDeReceitasDbContext(DbContextOptions<LivroDeReceitasDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<User> Users { get; set; }
}
