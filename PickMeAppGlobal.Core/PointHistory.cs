using System;

namespace PickMeAppGlobal.Core
{
  public class PointHistory
  {
    public string UserId { get; set; }

    public DateTime Date { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }
  }
}