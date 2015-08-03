using System.Data.Entity.ModelConfiguration;

using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data.Mapping
{
  internal class PointMapConfiguration : EntityTypeConfiguration<Point>
  {
    public PointMapConfiguration()
    {
      this.ToTable("Points").HasKey(m => new { m.UserId, m.Date });
    }
  }
}