using System;

namespace PickMeAppGlobal.Controllers.RequestModels
{
  public class UserInRoleQuery
  {
    public Guid UserId { get; set; }

    public string CurrentUserRole { get; set; }
  }
}