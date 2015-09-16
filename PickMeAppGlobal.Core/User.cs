using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PickMeAppGlobal.Core
{
  public class User : IdentityUser
  {
    public User(string name): base(name)
    {
    }

    public User()
    {
    }

    public string CurrentUserRole { get; set; }

    public string FacebookId { get; set; }

    public virtual List<Point> Points { get; set; }

    public virtual List<UserGroupInfo> UserGroupInfos { get; set; }
  }
}