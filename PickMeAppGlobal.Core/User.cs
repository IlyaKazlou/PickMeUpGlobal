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

    public string FacebookId { get; set; }

    public virtual List<Subscriber> Subscribers { get; set; }

    public virtual List<Point> Points { get; set; }

    public virtual List<Group> Groups { get; set; }

    public virtual List<Organization> Organizations { get; set; }

    public virtual List<Office> Offices { get; set; }
  }
}