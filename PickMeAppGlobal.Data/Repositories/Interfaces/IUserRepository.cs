using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Core.Enumes;

namespace PickMeAppGlobal.Data.Repositories.Interfaces
{
  public interface IUserRepository : IBaseRepository
  {
    Task<List<User>> GetAllAsync();

    Task<User> GetAsync(Guid userId);

    List<Subscriber> GetSubscribers(User user, UserRoles targetUserRole);

    void AddGeolocationPointToUser(Point point);

    List<Point> GetGeolocationPoints(User user, Func<Point, bool> expr = null);

    void AddUser(User user);

    void DeleteUser(Guid userId);
  }
}