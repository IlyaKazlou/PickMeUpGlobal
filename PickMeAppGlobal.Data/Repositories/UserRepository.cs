using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

    public async Task<User> GetAsync(string id)
    {
      return await this.DbSet.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<User> GetAsync(Expression<Func<User, bool>> expr)
    {
      return await this.DbSet.FirstOrDefaultAsync(expr);
    }

    public List<Point> GetGeolocationPoints(User user, Func<Point, bool> expr = null)
    {
      if (expr != null)
      {
        return user.Points.Where(expr).ToList();
      }

      return user.Points;
    }

    public async Task<Point> GetLatestPoint(string userId)
    {
      IQueryable<Point> userPoints = this.DbContext.Points.Where(p => p.UserId == userId).OrderByDescending(p => p.Date);
      var latestPoint = await userPoints.FirstOrDefaultAsync();
      return latestPoint;
    }

    public async Task<List<Point>> GetLatestPoints(params string[] userIds)
    {
      var query = DbContext.Points.Where(p => userIds.Contains(p.UserId)).AsQueryable();
      var userGroups = query.GroupBy(p => p.UserId).Select(g => g.OrderByDescending(p => p.Date));
      var points = new List<Point>();
      await userGroups.ForEachAsync(m => points.Add(m.First()));
      return points;
    }

    public async Task<List<Point>> GetUserLocationHistory(string userId, DateTime? from, DateTime? to)
    {
      var user = await this.GetAsync(userId);

      if (user == null) return new List<Point>();

      var points = user.Points ?? new List<Point>();
      if (from == null || to == null) return points;

      return points.Where(m => m.Date >= from && m.Date <= to).ToList();
    }

    public void AddGeolocationPointToUser(Point point)
    {
      point.Date = DateTime.UtcNow;
      this.DbContext.Points.Add(point);
    }

    public void AddUser(User user)
    {
      this.DbSet.Add(user);
    }

    public void DeleteUser(string userId)
    {
      var user = new User { Id = userId };
      this.DbSet.Attach(user);
      this.DbSet.Remove(user);
    }
  }
}