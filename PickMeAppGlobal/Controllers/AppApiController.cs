using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.Service;
using PickMeAppGlobal.Service.Interfaces;

namespace PickMeAppGlobal.Controllers
{
  public class AppApiController : ApiController
  {
    private IUserService UserService { get; set; }

    public AppApiController()
    {
      this.UserService = new UserService();
    }

    public void AddPoint(Guid userId, Point point)
    {
      this.UserService.AddGeolocationPointToUser(userId, point);
    }

    public async Task<List<Point>> GetAllUserPoints(Guid userId)
    {
      return await this.UserService.GetGeolocationPoints(userId);
    }
  }
}