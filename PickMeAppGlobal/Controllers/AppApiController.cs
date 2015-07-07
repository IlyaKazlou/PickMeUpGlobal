using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.Service;
using PickMeAppGlobal.Service.Interfaces;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class AppApiController : ApiController
  {
    private IUserService UserService { get; set; }

    public AppApiController()
    {
      this.UserService = new UserService();
    }

    public async void AddPoint([FromBody]Point point)
    {
      this.UserService.AddGeolocationPointToUser(point);
      await this.UserService.SaveChangesAsync();
      this.UserService.Dispose();
    }

    public async Task<List<UserViewModel>> GetAllUsers()
    {
      return await this.UserService.GetAllAsync();
    }
  }
}