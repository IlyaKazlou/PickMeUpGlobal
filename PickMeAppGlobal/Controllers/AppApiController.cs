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

    [HttpGet]
    public async Task<UserViewModel> GetUser(string userId)
    {
      return await this.UserService.GetAsync(userId, true);
    }

    public async Task<List<GroupViewModel>> GetAllGroups()
    {
      return await this.CommunityManagementService.GetAllGroups();
    }

    [HttpGet]
    public async Task<List<GroupViewModel>> GetAllUserGroups([FromUri]string userId)
    {
      return await this.CommunityManagementService.GetAllUserGroups(userId);
    }

    [HttpGet]
    public async Task<List<MetaTagViewModel>> GetGroupMetatags([FromUri]int groupId, [FromUri]int from, [FromUri]int to)
    {
      return await this.CommunityManagementService.GetGroupMetaTags(groupId, from, to);
    }

    [HttpPost]
    public async Task<List<SubscriberViewModel>> GetTargetSubscribers([FromBody]GetGroupSubscribersQuery query)
    {
      return await this.CommunityManagementService.GetGroupSubsctibers(query.GroupId, query.Tags, query.ConditionalOperator);
    }

    [HttpGet]
    public async Task<List<PointViewModel>> GetUserLocationHistory([FromUri]DateTime? from, [FromUri]DateTime? to, [FromUri]string userId)
    {
      return await this.UserService.GetUserLocationHistory(userId, from, to);
    }

    protected override void Dispose(bool disposing)
    {
     this.UserService.Dispose();
    }
  }
}