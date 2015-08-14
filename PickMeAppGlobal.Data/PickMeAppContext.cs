using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PickMeAppGlobal.Data
{
  public class PickMeAppContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public DbSet<Subscriber> Subscribers { get; set; }

    public DbSet<Point> Points { get; set; }

    public DbSet<Organization> Organizations { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public PickMeAppContext() : base("PickMeAppGlobal")
    {
      Database.SetInitializer(new PickMeAppDbInitializer());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new UserMapConfiguration());
      modelBuilder.Configurations.Add(new SubscriberMapConfiguration());
      modelBuilder.Configurations.Add(new PointMapConfiguration());

      //this.ModifyUserConfiguration(modelBuilder);

      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
      modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
      modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
    }

    private void ModifyUserConfiguration(DbModelBuilder modelBuilder)
    {
      var self = modelBuilder.Entity<User>();
      self.ToTable("Users").HasKey(m => m.Id);
      self.Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      self.Property(m => m.UserName).HasMaxLength(50);

      self.HasMany(m => m.Subscribers).WithRequired(m => m.User).HasForeignKey(m => m.UserId);

      self.HasMany(m => m.Points).WithRequired(m => m.User).HasForeignKey(m => m.UserId);

      self.HasMany(m => m.Groups).WithMany(g => g.Users).Map(
        mg =>
        {
          mg.ToTable("UserGroup");
          mg.MapLeftKey("UserId");
          mg.MapRightKey("GroupId");
        });

      self.HasMany(m => m.Offices).WithMany(g => g.Users).Map(
        mg =>
        {
          mg.ToTable("UserOffice");
          mg.MapLeftKey("UserId");
          mg.MapRightKey("OfficeId");
        });

      self.HasMany(m => m.Organizations).WithMany(g => g.Users).Map(
        mg =>
        {
          mg.ToTable("UserOrganization");
          mg.MapLeftKey("UserId");
          mg.MapRightKey("OrganizationId");
        });
    }
  }
}