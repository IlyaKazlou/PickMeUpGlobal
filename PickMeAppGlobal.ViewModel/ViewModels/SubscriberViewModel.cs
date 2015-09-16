
namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class SubscriberViewModel : IViewModel
  {
    public string Id { get; set; }

    public string UserName { get; set; }

    public PointViewModel LatestPoint { get; set; }
  }
}