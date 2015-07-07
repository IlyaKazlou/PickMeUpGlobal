using System.Linq;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.Mapping.Base;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.ViewModel.Mapping
{
  public class UserMapper : BaseMapper<UserViewModel, User>
  {

    public override UserViewModel GetViewModel(User obj)
    {
      var viewModel = GetEmptyViewModel();
      if (obj != null)
      {
        viewModel.Name = obj.Name;
        viewModel.PassengerHubName = obj.PassengerHubName;
        viewModel.DriverHubName = obj.DriverHubName;
        viewModel.Id = obj.Id;

        viewModel.Points = obj.Points.Select(point => new PointViewModel
        {
          Date = point.Date,
          Id = point.Id,
          Latitude = point.Latitude,
          Longitude = point.Longitude,
          UserId = point.UserId
        }).ToList();

        viewModel.Subscribers = obj.Subscribers.Select(subscriber => new SubscriberViewModel
        {
          HubName = subscriber.HubName,
          HubType = subscriber.HubType,
          SubscriberUserId = subscriber.SubscriberUserId,
          UserId = subscriber.UserId
        }).ToList();
      }
      return viewModel;
    }
  }
}