using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.Mapping.Base;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.ViewModel.Mapping
{
  public class PointMapper : BaseMapper<PointViewModel, Point>
  {
    public override PointViewModel GetViewModel(Point obj)
    {
      var viewModel = GetEmptyViewModel();
      if (obj != null)
      {
        viewModel.Date = obj.Date;
        viewModel.Id = obj.Id;
        viewModel.Latitude = obj.Latitude;
        viewModel.Longitude = obj.Longitude;
        viewModel.UserId = obj.UserId;
      }

      return viewModel;
    }
  }
}