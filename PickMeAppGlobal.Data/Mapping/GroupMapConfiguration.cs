
using PickMeAppGlobal.Core;
using System.Data.Entity.ModelConfiguration;

namespace PickMeAppGlobal.Data.Mapping
{
  internal class GroupMapConfiguration : EntityTypeConfiguration<Group>
  {
    public GroupMapConfiguration()
    {
      this.HasKey(m => m.Id).HasMany(m => m.MetaTags).WithRequired(m => m.Group).HasForeignKey(m => m.GroupId);

      this.HasMany(m => m.UserGroupInfos).WithRequired(m => m.Group).HasForeignKey(m => m.GroupId);
    }
  }
}