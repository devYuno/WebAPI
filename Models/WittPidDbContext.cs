using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WittPid.Models;

public class WittPidDbContext : DbContext
{
    public WittPidDbContext(DbContextOptions<WittPidDbContext> options) 
        : base(options)
    {
    }

    public DbSet<User> User => Set<User>();
    public DbSet<Fanfic> Fanfic => Set<Fanfic>();
    public DbSet<List> List => Set<List>();
    public DbSet<FanficList> FanficList => Set<FanficList>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var conn = Environment.GetEnvironmentVariable("SQL_CONNECTION")
                       ?? "Server=localhost;Database=WittPid;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(conn);
        }
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Fanfic>()
            .HasOne(f => f.Creator)
            .WithMany(u => u.CreatedFanfics)
            .HasForeignKey(f => f.CreatorId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<FanficList>()
            .HasOne(fl => fl.Fanfic)
            .WithMany(f => f.Lists)
            .HasForeignKey(fl => fl.FanficId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<FanficList>()
            .HasOne(fl => fl.List)
            .WithMany(l => l.Fanfics)
            .HasForeignKey(fl => fl.ListId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<List>()
            .HasOne(l => l.Creator)
            .WithMany(u => u.Lists)
            .HasForeignKey(l => l.CreatorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}



public class WittPidDbContextFactory : IDesignTimeDbContextFactory<WittPidDbContext>
{
    public WittPidDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WittPidDbContext>();
        var conn = Environment.GetEnvironmentVariable("SQL_CONNECTION")
                   ?? "Server=localhost;Database=WittPid;Trusted_Connection=True;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(conn);

        return new WittPidDbContext(optionsBuilder.Options);
    }
}
