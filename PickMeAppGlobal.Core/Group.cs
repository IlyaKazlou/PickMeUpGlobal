
using System.Collections.Generic;

using PickMeAppGlobal.Core.Base;

namespace PickMeAppGlobal.Core
{
  public class Group : BaseEntity
  {
    public string Name { get; set; }

    public int OfficeId { get; set; }

    public virtual Office Office { get; set; }

    public virtual List<User> Users { get; set; }
  }
}