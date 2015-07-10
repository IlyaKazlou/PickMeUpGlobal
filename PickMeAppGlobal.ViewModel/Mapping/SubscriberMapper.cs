using System.Collections.Generic;
using System.Linq;

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

    private SubscriberViewModel GetViewModel(Subscriber obj, Point latestPoint)
    {
      var viewModel = this.GetViewModel(obj);
      viewModel.LatestPoint = new PointViewModel { Date = latestPoint.Date, Latitude = latestPoint.Latitude, Longitude = latestPoint.Longitude };
      return viewModel;
    }

    public List<SubscriberViewModel> GetViewModelList(List<Subscriber> list, List<Point> latestPoints)
    {
      var vml = new List<SubscriberViewModel>();
      if (list != null && list.Any())
        list.ForEach(el =>
        {
          var point = latestPoints.FirstOrDefault(p => p.UserId == el.SubscriberUserId);
          vml.Add(point != null ? this.GetViewModel(el, point) : this.GetViewModel(el));
        });
      return vml;
    }
  }
}