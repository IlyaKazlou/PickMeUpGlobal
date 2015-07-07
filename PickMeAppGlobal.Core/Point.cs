﻿using System;

using PickMeAppGlobal.Core.Base;

namespace PickMeAppGlobal.Core
{
  public class Point : BaseEntity
  {
    public Guid UserId { get; set; }

    public DateTime Date { get; set; }

    public virtual User User { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }
  }
}