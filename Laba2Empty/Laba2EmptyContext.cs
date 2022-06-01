using Microsoft.EntityFrameworkCore;
using Laba2Empty.Models;

namespace Laba2Empty;

public class Laba2EmptyContext : DbContext
{
    public Laba2EmptyContext()
    {
    }

    public Laba2EmptyContext(DbContextOptions<Laba2EmptyContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Character> Characters { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Developer> Developers { get; set; }
    public virtual DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id)
            .UseIdentityColumn();
            entity.HasIndex(e => e.CategoryName)
            .IsUnique();

            entity.HasMany(d => d.Games)
            .WithOne(e => e.Category)
            .HasForeignKey(p => p.CategoryID)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.Property(e => e.ID)
            .UseIdentityColumn();
            entity.HasIndex(e => e.CharacterName)
            .IsUnique();

            entity.HasOne(d => d.Game)
            .WithMany(e => e.Characters)
            .HasForeignKey(e => e.ID)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.ID)
            .UseIdentityColumn();
            entity.HasIndex(e => e.CountryName)
            .IsUnique();

            entity.HasMany(d => d.Developers)
            .WithOne(e => e.Country)
            .HasForeignKey(e => e.CountryID)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Developer>(entity =>
        {
            entity.Property(e => e.ID)
            .UseIdentityColumn();
            entity.Property(e => e.Type)
            .HasMaxLength(255);

            entity.HasOne(d => d.Game)
            .WithMany(e => e.Developers)
            .HasForeignKey(d => d.ID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Country)
            .WithMany(e => e.Developers)
            .HasForeignKey(d => d.ID)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.Property(e => e.ID)
            .UseIdentityColumn();
            entity.HasIndex(e => e.GameName)
            .IsUnique();
            entity.Property(e => e.Info)
            .HasMaxLength(255);

            entity.HasOne(d => d.Category)
            .WithMany(e => e.Games)
            .HasForeignKey(e => e.CategoryID)
            .OnDelete(DeleteBehavior.Cascade);



            entity.HasMany(d => d.Characters)
            .WithOne(e => e.Game)
            .HasForeignKey(e => e.GameID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(d => d.Developers)
            .WithOne(e => e.Game)
            .HasForeignKey(e => e.GameID)
            .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
