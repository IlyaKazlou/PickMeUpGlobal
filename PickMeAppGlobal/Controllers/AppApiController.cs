using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
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

    public async Task AddPoint([FromBody]Point point)
    {
      this.UserService.AddGeolocationPointToUser(point);
      await this.UserService.SaveChangesAsync();
    }

    public async Task<List<UserViewModel>> GetAllUsers()
    {
      return await this.UserService.GetAllAsync();
    }

    public async Task<List<OrganizationViewModel>> GetAllOrganizations()
    {
      return await this.CommunityManagementService.GetAllOrganizations();
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