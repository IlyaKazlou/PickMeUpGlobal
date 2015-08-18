using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

using PickMeAppGlobal.Controllers.RequestModels;
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

    private ICommunityManagementService CommunityManagementService { get; set; }

    public AppApiController()
    {
      this.UserService = new UserService();
      this.CommunityManagementService = new CommunityManagementService();
    }

    public async Task<IHttpActionResult> AddPoint([FromBody]Point point)
    {
      this.UserService.AddGeolocationPointToUser(point);
      try
      {
        await this.UserService.SaveChangesAsync();
      }
      catch (Exception e)
      {
        return new InternalServerErrorResult(Request);
      }

      return new OkResult(Request);
    }

    public async Task<List<UserViewModel>> GetAllUsers()
    {
      return await this.UserService.GetAllAsync();
    }

    public async Task<List<OrganizationViewModel>> GetAllOrganizations()
    {
      return await this.CommunityManagementService.GetAllOrganizations();
    }

    [HttpGet]
    public async Task<List<OrganizationViewModel>> GetAllUserOrganizations([FromUri]string userId)
    {
      return await this.CommunityManagementService.GetAllUserOrganizations(userId);
    }

    [HttpPost]
    public async Task<List<SubscriberViewModel>> GetUserSubscribers([FromBody]UserInRoleQuery query)
    {
      return await this.UserService.GetSubscribers(query.UserId, query.CurrentUserRole);
    }

    protected override void Dispose(bool disposing)
    {
     this.UserService.Dispose();
    }
  }
}