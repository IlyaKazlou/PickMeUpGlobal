using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Repositories.Interfaces;

namespace PickMeAppGlobal.Data.Repositories
{
  public class UserRepository : BaseRepository, IUserRepository
  {
    protected DbSet<User> DbSet { get; set; }

    public UserRepository()
    {
      this.DbSet = this.DbContext.Users;
    }

    public async Task<List<User>> GetAllAsync()
    {
      return await this.DbSet.ToListAsync();
    }

    public async Task<User> GetAsync(int id)
    {
      return await this.DbSet.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<List<Subscriber>> GetSubscribers(int userId, string targetUserRole)
    {
      var user = await this.GetAsync(userId);
      return user.Subscribers.Where(m => m.HubType == targetUserRole).ToList();
    }

    public List<Point> GetGeolocationPoints(User user, Func<Point, bool> expr = null)
    {
      if (expr != null)
      {
        return user.Points.Where(expr).ToList();
      }

      return user.Points;
    }

    public async Task<Point> GetLatestPoint(int userId)
    {
      IQueryable<Point> userPoints = this.DbContext.Points.Where(p => p.UserId == userId).OrderByDescending(p => p.Date);
      var latestPoint = await userPoints.FirstAsync();
      return latestPoint;
    }

    public async Task<List<Point>> GetLatestPoints(params int[] userIds)
    {
      var query = DbContext.Points.Where(p => userIds.Contains(p.UserId)).AsQueryable();
      var now = DateTime.Now;
      var pastDate = new DateTime(now.Year, now.Month - 2, 1);
      query = query.Where(p => p.Date > pastDate);

      var userGroups = query.GroupBy(p => p.UserId).Select(g => g.OrderByDescending(p => p.Date));
      var points = new List<Point>();
      await userGroups.ForEachAsync(m => points.Add(m.First()));
      return points;
    }

    public void AddGeolocationPointToUser(Point point)
    {
      point.Date = DateTime.Now;
      this.DbContext.Points.Add(point);
    }

    public void AddUser(User user)
    {
      this.DbSet.Add(user);
    }

    public void DeleteUser(int userId)
    {
      var user = new User { Id = userId };
      this.DbSet.Attach(user);
      this.DbSet.Remove(user);
    }
  }
}