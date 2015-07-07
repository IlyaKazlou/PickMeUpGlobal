using System;

namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class PointViewModel : IViewModel
  {
    public Guid UserId { get; set; }

    public DateTime Date { get; set; }

    public Guid Id { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }
  }
}