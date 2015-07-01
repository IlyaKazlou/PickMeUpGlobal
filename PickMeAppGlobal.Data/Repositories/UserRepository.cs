using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Core.Enumes;
using PickMeAppGlobal.Data.Repositories.Interfaces;

namespace PickMeAppGlobal.Data.Repositories
{
  public class UserRepository : IUserRepository
  {
    public PickMeAppContext DbContext { get; set; }
    private DbSet<User> DbSet { get; set; }

    public UserRepository()
    {
      this.DbContext = new PickMeAppContext();
      this.DbSet = this.DbContext.Users;
    }

    public async Task<List<User>> GetAllAsync()
    {
      return await this.DbSet.ToListAsync();
    }

    public async Task<User> GetAsync(Guid id)
    {
      return await this.DbSet.FirstOrDefaultAsync(m => m.Id == id);
    }


    public async Task<List<Subscriber>> GetSubscribersAsync(Guid userId, UserRoles targetUserRole)
    {
      var type = targetUserRole.ToString();
      var subscribers = await this.DbContext.Subscribers.Where(m => m.UserId == userId && m.HubType == type).ToListAsync();
      return subscribers;
    }

    public Task<Point> GetPointsAsync(Guid userId, DateTime fromDate, DateTime toDate)
    {
      throw new NotImplementedException();
    }
  }
}