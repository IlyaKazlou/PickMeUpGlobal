
using System.Collections.Generic;

using PickMeAppGlobal.Core.Base;

namespace PickMeAppGlobal.Core
{
  public class Office : BaseEntity
  {
    public string Name { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int OrganizationId { get; set; }

    public virtual Organization Organization { get; set; }

    public virtual List<User> Users { get; set; }

    public virtual List<Group> Groups { get; set; }
  }
}