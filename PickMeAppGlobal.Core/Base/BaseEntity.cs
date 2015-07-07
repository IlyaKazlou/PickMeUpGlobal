using System;

namespace PickMeAppGlobal.Core.Base
{
  [Serializable]
  public class BaseEntity : IEntity
  {
    public Guid Id { get; set; }
  }
}