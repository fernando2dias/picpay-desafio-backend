using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Domain.Entities;
using PicPaySimplificado.Domain.Enums;

namespace PicPaySimplificado.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.Document).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.HasOne(e => e.Wallet)
                    .WithOne()
                    .HasForeignKey<Wallet>(w => w.UserId);

                entity.HasData(
                    new
                    {
                        Id = Guid.Parse("b4571002-0a3e-4174-9d7f-4fee06e74886"),
                        FullName = "João Silva",
                        Document = "12345678900",
                        Email = "joao.silva@gmail.com",
                        Type = UserType.Common
                    },

                    new
                    {
                        Id = Guid.Parse("cc969c84-7e02-4410-9375-42f1585aef18"),
                        FullName = "Francisco Chicote",
                        Document = "12300564544",
                        Email = "francisco.chico@gmail.com",
                        Type = UserType.Store
                    }
                 );

                modelBuilder.Entity<Wallet>(entity =>
                    {
                        entity.HasKey(e => e.Id);
                        entity.Property(e => e.Balance).HasColumnType("decimal(18,2)");

                        entity.HasData(
                            new
                            {
                                Id = Guid.Parse("c8f0a7c0-3c7a-4fcb-bc17-1c1a8b5b0c11"),
                                UserId = Guid.Parse("b4571002-0a3e-4174-9d7f-4fee06e74886"),
                                Balance = 100m
                            },
                            new
                            {
                                Id = Guid.Parse("7a8183bc-0834-425d-92ab-b5ddfb381445"),
                                UserId = Guid.Parse("cc969c84-7e02-4410-9375-42f1585aef18"),
                                Balance = 10m
                            }
                        );
                    });

                modelBuilder.Entity<Transaction>(entity =>
                    {
                        entity.HasKey(e => e.Id);
                        entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                        entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    });


            });
        }
    }
}
