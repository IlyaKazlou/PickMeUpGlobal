using System.Data.Entity;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;

using PickMeAppGlobal.Data.Migrations;

namespace PickMeAppGlobal.Data
{
  public class PickMeAppContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public DbSet<Point> Points { get; set; }

    public DbSet<PointHistory> PointHistories { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public PickMeAppContext() : base("PickMeAppGlobal")
    {
      Database.SetInitializer(new MigrateDatabaseToLatestVersion<PickMeAppContext, PickUpConfiguration>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new UserMapConfiguration());
      modelBuilder.Configurations.Add(new PointMapConfiguration());
      modelBuilder.Configurations.Add(new GroupMapConfiguration());

      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<MetaTag>().HasKey<string>(m => m.Name);

      modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
      modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
      modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

      modelBuilder.Entity<UserGroupInfo>().ToTable("UserGroupInfo").HasKey(m => new { m.UserId, m.GroupId });

      modelBuilder.Entity<PointHistory>().ToTable("PointHistory").HasKey(m => new { m.UserId, m.Date });
      modelBuilder.Entity<PointHistory>().Property(m => m.Latitude).HasPrecision(32, 24);
      modelBuilder.Entity<PointHistory>().Property(m => m.Longitude).HasPrecision(32, 24);
    }
  }
}