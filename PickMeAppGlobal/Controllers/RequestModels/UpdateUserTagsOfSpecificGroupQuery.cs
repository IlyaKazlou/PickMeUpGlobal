
namespace PickMeAppGlobal.Controllers.RequestModels
{
  public class UpdateUserTagsOfSpecificGroupQuery
  {
    public int GroupId { get; set; }

    public string UserId { get; set; }

    public string[] Tags { get; set; }
  }
}