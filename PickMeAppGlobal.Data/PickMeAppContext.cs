using System.Data.Entity;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Mapping;

namespace PickMeAppGlobal.Data
{
  public class PickMeAppContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public DbSet<Subscriber> Subscribers { get; set; }

    public PickMeAppContext() : base("PickMeAppGlobal")
    {
      Database.SetInitializer(new DropCreateDatabaseAlways<PickMeAppContext>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new UserMapConfiguration());
      modelBuilder.Configurations.Add(new SubscriberMapConfiguration());
      base.OnModelCreating(modelBuilder);
    }
  }
}