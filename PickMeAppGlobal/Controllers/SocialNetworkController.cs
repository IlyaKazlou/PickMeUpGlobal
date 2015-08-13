using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

using PickMeAppGlobal.Service.Interfaces;
using PickMeAppGlobal.Service.SocialServices;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Controllers
{
  //[Authorize]
  [RoutePrefix("api/Social")]
  public class SocialNetworkController : ApiController
  {
    private ISocialNetworkService _socialService;

    public async Task<UserViewModel> GetMe(string token)
    {
      return await this.GetService(token).GetMe();
    }

    public async Task<IList<object>> GetFriends(string token)
    {
      return await this.GetService(token).GetFriends();
    }

    private ISocialNetworkService GetService(string token)
    {
      return _socialService ?? (_socialService = new FacebookService(token));
    }
  }
}