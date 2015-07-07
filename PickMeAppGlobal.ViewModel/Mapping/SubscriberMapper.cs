using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.Mapping.Base;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.ViewModel.Mapping
{
  public class SubscriberMapper : BaseMapper<SubscriberViewModel, Subscriber>
  {
    public override SubscriberViewModel GetViewModel(Subscriber obj)
    {
      var viewModel = GetEmptyViewModel();
      if (obj != null)
      {
        viewModel.HubName = obj.HubName;
        viewModel.HubType = obj.HubType;
        viewModel.SubscriberUserId = obj.SubscriberUserId;
        viewModel.UserId = obj.UserId;
      }

      return viewModel;
    }
  }
}