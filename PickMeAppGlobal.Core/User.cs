using System;
using System.Collections.Generic;

namespace PickMeAppGlobal.Core
{
  public class User
  {
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string DriverHubName { get; set; }

    public string PassengerHubName { get; set; }

    public virtual List<Subscriber> Subscribers { get; set; }
  }
}