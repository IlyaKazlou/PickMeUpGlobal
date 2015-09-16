
namespace PickMeAppGlobal.Core
{
  public class UserGroupInfo
  {
    public string UserId { get; set; }

    public int GroupId { get; set; }

    public string Tags { get; set; }

    public virtual User User { get; set; }

    public virtual Group Group { get; set; }
  }
}