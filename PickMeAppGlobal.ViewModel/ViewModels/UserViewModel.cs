using System;
using System.Collections.Generic;

namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class UserViewModel : IViewModel
  {
    public string Name { get; set; }

    public string DriverHubName { get; set; }

    public string PassengerHubName { get; set; }

    public Guid Id { get; set; }

    public virtual List<SubscriberViewModel> Subscribers { get; set; }

    public virtual List<PointViewModel> Points { get; set; }
  }
}