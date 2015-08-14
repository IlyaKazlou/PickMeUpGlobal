using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data.Mapping
{
  internal class UserMapConfiguration : EntityTypeConfiguration<User>
  {
    public UserMapConfiguration()
    {
      this.ToTable("Users").HasKey(m => m.Id);
      this.Property(m => m.UserName).HasMaxLength(50);

      this.HasMany(m => m.Subscribers).WithRequired(m => m.User).HasForeignKey(m => m.UserId);

      this.HasMany(m => m.Points).WithRequired(m => m.User).HasForeignKey(m => m.UserId);

      this.HasMany(m => m.Groups).WithMany(g => g.Users).Map(
        mg =>
          {
            mg.ToTable("UserGroup");
            mg.MapLeftKey("UserId");
            mg.MapRightKey("GroupId");
          });

      this.HasMany(m => m.Offices).WithMany(g => g.Users).Map(
        mg =>
        {
          mg.ToTable("UserOffice");
          mg.MapLeftKey("UserId");
          mg.MapRightKey("OfficeId");
        });

      this.HasMany(m => m.Organizations).WithMany(g => g.Users).Map(
        mg =>
        {
          mg.ToTable("UserOrganization");
          mg.MapLeftKey("UserId");
          mg.MapRightKey("OrganizationId");
        });
    }
  }
}