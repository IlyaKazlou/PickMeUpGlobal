
namespace PickMeAppGlobal.Controllers.RequestModels
{
  public class GetGroupSubscribersQuery
  {
    public int GroupId { get; set; }

    public string ConditionalOperator { get; set; }

    public string RoleOfUser { get; set; }

    public string[] Tags { get; set; }
  }
}