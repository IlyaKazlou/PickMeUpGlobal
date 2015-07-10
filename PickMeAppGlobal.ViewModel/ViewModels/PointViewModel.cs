using System;

namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class PointViewModel : IViewModel
  {
    public DateTime Date { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }
  }
}