
namespace PickMeAppGlobal.Core
{
  public class Subscriber
  {
    public int UserId { get; set; }

    public int SubscriberUserId { get; set; }

    public virtual User User { get; set; }

    public string HubName { get; set; }

    public string HubType { get; set; }
  }
}