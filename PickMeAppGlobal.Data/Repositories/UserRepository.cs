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
  public class UserRepository : BaseRepository, IUserRepository
  {
    private DbSet<User> DbSet { get; set; }

    public UserRepository()
    {
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

    public List<Point> GetGeolocationPoints(User user, Func<Point, bool> expr = null)
    {
      if (expr != null)
      {
        return user.Points.Where(expr).ToList();
      }

      return user.Points;
    }

    public async void AddGeolocationPointToUser(Guid userId, Point point)
    {
      var user = await this.GetAsync(userId);
      if (user.Points == null)
      {
        user.Points = new List<Point>();
      }

      user.Points.Add(point);
    }

    public void AddUser(User user)
    {
      this.DbSet.Add(user);
    }

    public void DeleteUser(Guid userId)
    {
      var user = new User { Id = userId };
      this.DbSet.Attach(user);
      this.DbSet.Remove(user);
    }
  }
}