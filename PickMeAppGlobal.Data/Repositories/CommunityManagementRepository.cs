using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Repositories.Interfaces;

namespace PickMeAppGlobal.Data.Repositories
{
  public class CommunityManagementRepository : BaseRepository, ICommunityManagementRepository
  {
    protected DbSet<Group> DbSet { get; set; }

    public CommunityManagementRepository()
    {
      this.DbSet = this.DbContext.Groups;
    }

    public async Task<Group> GetAsync(int groupId)
    {
      return await this.DbSet.FirstOrDefaultAsync(m => m.Id == groupId);
    }

    public async Task<List<Group>> GetAllUserGroups(string userId)
    {
      if (string.IsNullOrEmpty(userId)) return null;
      
      var user = await this.DbContext.Users.FirstOrDefaultAsync(m => m.Id == userId);

      var groupKeys = user.UserGroupInfos.Select(m => m.GroupId);
      var groups = await this.DbContext.Groups.Where(m => groupKeys.Contains(m.Id)).ToListAsync();

      return groups;
    }

    public async Task<List<Group>> GetAllGroups()
    {
      return await this.DbSet.ToListAsync();
    }

    public async Task<List<MetaTag>> GetGroupMetaTags(int groupId, int from, int to)
    {
      var group = await this.DbSet.FirstOrDefaultAsync(m => m.Id == groupId);
      if (group == null) return new List<MetaTag>();
      return group.MetaTags.Skip(from).Take(to).ToList();
    }

    public async Task<List<User>> GetGroupSubsctibers(int groupId, string[] tags, string conditionalOperator = "&&")
    {
      var group = await this.GetAsync(groupId);

      var groupInfos = group.UserGroupInfos;

      List<UserGroupInfo> filteredGroupInfos = null;

      if (tags == null || !tags.Any())
      {
        filteredGroupInfos = groupInfos;
      }
      else
      {
        filteredGroupInfos = conditionalOperator == "||"
                               ? groupInfos.Where(m => m.Tags.Split(',').Intersect(tags).Any()).ToList()
                               : groupInfos.Where(m => m.Tags.Split(',').Intersect(tags).Count() == tags.Count()).ToList();
      }

      var userKeys = filteredGroupInfos.Select(m => m.UserId);
      return await this.DbContext.Users.Where(m => userKeys.Contains(m.Id)).ToListAsync();
    }
  }
}