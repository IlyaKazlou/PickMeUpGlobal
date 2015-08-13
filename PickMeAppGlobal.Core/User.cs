using System.Collections.Generic;
using PickMeAppGlobal.Core.Base;

namespace PickMeAppGlobal.Core
{
  public class User : BaseEntity
  {
    public string Name { get; set; }

    public string SecondName { get; set; }

    public string FacebookId { get; set; }

    public virtual List<Subscriber> Subscribers { get; set; }

    public virtual List<Point> Points { get; set; }

    public virtual List<Group> Groups { get; set; }

    public virtual List<Organization> Organizations { get; set; }

    public virtual List<Office> Offices { get; set; }
  }
}