using System;

namespace PickMeAppGlobal.Core
{
  public class Subscriber
  {
    public Guid UserId { get; set; }

    public Guid SubscriberUserId { get; set; }

    public virtual User User { get; set; }

    public string HubName { get; set; }

    public string HubType { get; set; }
  }
}