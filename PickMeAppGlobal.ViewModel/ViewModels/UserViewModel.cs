using System.Collections.Generic;

namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class UserViewModel : IViewModel
  {
    public string Name { get; set; }

    public string SecondName { get; set; }

    public string DriverHubName { get; set; }

    public string PassengerHubName { get; set; }

    public string CoverPhoto { get; set; }

    public int Id { get; set; }

    public string FacebookId { get; set; }

    public virtual List<SubscriberViewModel> Subscribers { get; set; }
  }
}