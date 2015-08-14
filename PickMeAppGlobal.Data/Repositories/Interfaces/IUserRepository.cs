using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data.Repositories.Interfaces
{
  public interface IUserRepository : IBaseRepository
  {
    Task<List<User>> GetAllAsync();

    Task<User> GetAsync(string userId);

    Task<List<Subscriber>> GetSubscribers(string userId, string targetUserRole);

    void AddGeolocationPointToUser(Point point);

    List<Point> GetGeolocationPoints(User user, Func<Point, bool> expr = null);

    Task<Point> GetLatestPoint(string userId);

    Task<List<Point>> GetLatestPoints(params string[] userIds);

    void AddUser(User user);

    void DeleteUser(string userId);
  }
}