using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Repositories.Interfaces;

namespace PickMeAppGlobal.Service.Interfaces
{
  public interface IUserService : IUserRepository
  {
    Task<List<Point>> GetGeolocationPoints(Guid userId, Func<Point, bool> expr = null);
  }
}