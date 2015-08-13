using System.Data.Entity;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Mapping;

namespace PickMeAppGlobal.Data
{
  public class PickMeAppContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public DbSet<Subscriber> Subscribers { get; set; }

    public DbSet<Point> Points { get; set; }

    public DbSet<Organization> Organizations { get; set; }

    public PickMeAppContext() : base("PickMeAppGlobal")
    {
      Database.SetInitializer(new PickMeAppDbInitializer());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new UserMapConfiguration());
      modelBuilder.Configurations.Add(new SubscriberMapConfiguration());
      modelBuilder.Configurations.Add(new PointMapConfiguration());

      base.OnModelCreating(modelBuilder);
    }
  }
}