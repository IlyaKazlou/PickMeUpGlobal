
namespace PickMeAppGlobal.Core
{
  public class Subscriber
  {
    public string UserId { get; set; }

    public string SubscriberUserId { get; set; }

    public virtual User User { get; set; }

    public string HubName { get; set; }

    public string HubType { get; set; }
  }
}