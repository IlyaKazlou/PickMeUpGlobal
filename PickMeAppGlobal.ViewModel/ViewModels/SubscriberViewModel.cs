using System;

namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class SubscriberViewModel : IViewModel
  {
    public int UserId { get; set; }

    public int SubscriberUserId { get; set; }

    public string HubName { get; set; }

    public string HubType { get; set; }

    public PointViewModel LatestPoint { get; set; }
  }
}