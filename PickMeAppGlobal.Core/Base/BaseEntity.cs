using System;

namespace PickMeAppGlobal.Core.Base
{
  [Serializable]
  public class BaseEntity : IEntity
  {
    public int Id { get; set; }
  }
}