using System.Collections.Generic;

using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Service.Infrastructure
{
  public class PointEqualityComparer : EqualityComparer<Point>
  {
    public override bool Equals(Point p1, Point p2)
    {
      var dateDiff = (p2.Date - p1.Date).TotalSeconds;
      if (p1.Longitude == p2.Longitude && p1.Latitude == p2.Latitude && dateDiff <= 360)
      {
        return true;
      }
      else
      {
        return false;
      }
    }


    public override int GetHashCode(Point p)
    {
      return p.UserId.GetHashCode();
    }
  }
}