using confitec.Entities;
using Microsoft.EntityFrameworkCore;

namespace confitec.Persistence
{
  public class UsersDbContext : DbContext
  {
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>(entity =>
      {
        entity.HasKey(user => user.Id);

        entity.Property(user => user.Nome).IsRequired(true);
        entity.Property(user => user.Sobrenome).IsRequired(true);
        entity.Property(user => user.Email).IsRequired(true);
        entity.Property(user => user.DataNascimento).IsRequired(true);
        entity.Property(user => user.Escolaridade).IsRequired(true).HasColumnType("int");
      });
    }

  }
}
