using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.Core.Enumes;

namespace PickMeAppGlobal.Data.Repositories.Interfaces
{
  public interface IUserRepository
  {
    Task<List<User>> GetAllAsync();

    Task<User> GetAsync(Guid userId);

    Task<List<Subscriber>> GetSubscribersAsync(Guid userId, UserRoles targetUserRole);

    Task<Point> GetPointsAsync(Guid userId, DateTime fromDate, DateTime toDate);
  }
}