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
        viewModel.UserName = obj.UserName;
        viewModel.Id = obj.Id;

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