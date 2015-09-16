using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.Mapping.Base;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.ViewModel.Mapping
{
  public class SubscriberMapper : IMap
  {
    protected PointMapper PointMapper { get; set; }

    public SubscriberMapper()
    {
      this.PointMapper = new PointMapper();
    }

    public SubscriberViewModel GetViewModel(User obj, Point latestPoint)
    {
      var viewModel = new SubscriberViewModel
      {
        Id = obj.Id,
        UserName = obj.UserName,
        LatestPoint = latestPoint != null ? this.PointMapper.GetViewModel(latestPoint) : null
      };

      return viewModel;
    }
  }
}