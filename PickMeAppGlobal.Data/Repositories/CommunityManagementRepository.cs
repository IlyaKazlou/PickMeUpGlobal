using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Repositories.Interfaces;

namespace PickMeAppGlobal.Data.Repositories
{
  public class CommunityManagementRepository : BaseRepository, ICommunityManagementRepository
  {
    protected DbSet<Organization> DbSet { get; set; }

    public CommunityManagementRepository()
    {
      this.DbSet = this.DbContext.Organizations;
      this.DbSet.Include("Offices");
    }

    public async Task<List<Organization>> GetAllUserOrganizations(string userId)
    {
      var user = await this.DbContext.Users.FirstOrDefaultAsync(m => m.Id == userId);
      return user.Organizations;
    }

    public async Task<List<Organization>> GetAllOrganizations()
    {
      return await this.DbSet.ToListAsync();
    }
  }
}