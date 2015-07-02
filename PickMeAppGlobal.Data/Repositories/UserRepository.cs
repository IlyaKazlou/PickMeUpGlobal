using System;
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

    public List<Subscriber> GetSubscribers(User user, UserRoles targetUserRole)
    {
      var currentUserRole = targetUserRole.ToString();
      return user.Subscribers.Where(m => m.HubType == currentUserRole).ToList();
    }

    public void AddUser(User user)
    {
      this.DbSet.Add(user);
    }

    public void UpdateUser(User user)
    {
      this.DbContext.Entry(user).State = EntityState.Modified;
    }

    public void DeleteUser(Guid userId)
    {
      var user = new User { Id = userId };
      this.DbContext.Entry(user).State = EntityState.Deleted; 
    }

    public async void SaveChangesAsync()
    {
      await this.DbContext.SaveChangesAsync();
    }
  }
}