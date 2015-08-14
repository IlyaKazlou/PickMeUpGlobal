
namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class SubscriberViewModel : IViewModel
  {
    public string UserId { get; set; }

    public string SubscriberUserId { get; set; }

    public string HubName { get; set; }

    public string HubType { get; set; }

    public PointViewModel LatestPoint { get; set; }
  }
}