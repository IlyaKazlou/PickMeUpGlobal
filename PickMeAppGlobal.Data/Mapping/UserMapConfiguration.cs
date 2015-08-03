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
      this.Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      this.Property(m => m.Name).HasMaxLength(50);
      this.HasMany(m => m.Subscribers).WithRequired(m => m.User).HasForeignKey(m => m.UserId);
      this.HasMany(m => m.Points).WithRequired(m => m.User).HasForeignKey(m => m.UserId);
    }
  }
}