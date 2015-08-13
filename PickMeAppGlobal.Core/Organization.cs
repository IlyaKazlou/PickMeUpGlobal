using System;
using System.Collections.Generic;

using PickMeAppGlobal.Core.Base;

namespace PickMeAppGlobal.Core
{
  public class Organization : BaseEntity
  {
    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public int CreatorId { get; set; }

    public virtual List<Office> Offices { get; set; }

    public virtual List<User> Users { get; set; }
  }
}