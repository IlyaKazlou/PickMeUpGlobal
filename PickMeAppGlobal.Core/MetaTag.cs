﻿
namespace PickMeAppGlobal.Core
{
  public class MetaTag
  {
    public string Name { get; set; }

    public string Description { get; set; }

    public string Defines { get; set; }

    public int GroupId { get; set; }

    public virtual Group Group { get; set; }
  }
}