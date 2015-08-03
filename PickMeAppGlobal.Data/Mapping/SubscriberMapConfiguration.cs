using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data.Mapping
{
  internal class SubscriberMapConfiguration : EntityTypeConfiguration<Subscriber>
  {
    public SubscriberMapConfiguration()
    {
      this.ToTable("Subscribers").HasKey(m => new { m.UserId, m.SubscriberUserId, m.HubType });
    }
  }
}