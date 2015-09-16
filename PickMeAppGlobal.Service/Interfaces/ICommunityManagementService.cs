
using System.Collections.Generic;
using System.Threading.Tasks;

using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Service.Interfaces
{
  public interface ICommunityManagementService
  {
    Task<List<GroupViewModel>> GetAllGroups();

    Task<List<GroupViewModel>> GetAllUserGroups(string userId);

    Task<List<MetaTagViewModel>> GetGroupMetaTags(int groupId, int from, int to);

    Task<List<SubscriberViewModel>> GetGroupSubsctibers(int groupId, string[] tags, string conditionalOperator);
  }
}