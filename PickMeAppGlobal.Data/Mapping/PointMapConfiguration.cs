using System.Data.Entity.ModelConfiguration;

using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data.Mapping
{
  internal class PointMapConfiguration : EntityTypeConfiguration<Point>
  {
    public PointMapConfiguration()
    {
      this.ToTable("Points").HasKey(m => new { m.UserId, m.Date });
      this.Property(m => m.Latitude).HasPrecision(32, 24);
      this.Property(m => m.Longitude).HasPrecision(32, 24);
    }
  }
}