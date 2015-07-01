using System;

using PickMeAppGlobal.Core.Base;

namespace PickMeAppGlobal.Core
{
  public class Point : BaseEntity
  {
    public Guid UserId { get; set; }

    public DateTime Date { get; set; }

    public virtual User User { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }
  }
}