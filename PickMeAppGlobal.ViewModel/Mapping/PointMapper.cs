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
        viewModel.Latitude = obj.Latitude;
        viewModel.Longitude = obj.Longitude;
      }

      return viewModel;
    }
  }
}