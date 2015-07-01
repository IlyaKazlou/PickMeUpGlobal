using System.Collections.Generic;
using PickMeAppGlobal.Core.Base;

namespace PickMeAppGlobal.Core
{
  public class User : BaseEntity
  {
    public string Name { get; set; }

    public string DriverHubName { get; set; }

    public string PassengerHubName { get; set; }

    public virtual List<Subscriber> Subscribers { get; set; }

    public virtual List<Point> Points { get; set; }
  }
}