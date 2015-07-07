using System;

namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class SubscriberViewModel : IViewModel
  {
    public Guid UserId { get; set; }

    public Guid SubscriberUserId { get; set; }

    public string HubName { get; set; }

    public string HubType { get; set; }
  }
}