using System.Collections.Generic;
using System.Threading.Tasks;

using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data.Repositories.Interfaces
{
  public interface ICommunityManagementRepository
  {
    Task<List<Group>> GetAllGroups();

    Task<Group> GetAsync(int groupId);

    Task<List<Group>> GetAllUserGroups(string userId);

    Task<List<MetaTag>> GetGroupMetaTags(int groupId, int from, int to);

    Task<List<User>> GetGroupSubsctibers(int groupId, string[] tags, string conditionalOperator);
  }
}