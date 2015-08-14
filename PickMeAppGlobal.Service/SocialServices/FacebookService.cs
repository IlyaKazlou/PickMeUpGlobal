using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook;
using PickMeAppGlobal.Service.Interfaces;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Service.SocialServices
{
  public class FacebookService : ISocialNetworkService
  {
    protected FacebookClient FacebookClient { get; set; }

    public FacebookService(string token)
    {
      this.FacebookClient = new FacebookClient(token);
    }

    public async Task<UserViewModel> GetMe()
    {
      var userViewModel = new UserViewModel();

      this.FacebookClient.GetCompleted +=
          (o, e) =>
          {
            var result = (IDictionary<string, object>)e.GetResultData();
            userViewModel.FacebookId = (string)result["id"];
            userViewModel.UserName = (string)result["name"];
          };

      await this.FacebookClient.GetTaskAsync("me?fields=name,id,email,picture");

      return userViewModel;
    }

    public async Task<IList<object>> GetFriends()
    {
      IList<object> data = null;
      var query = string.Format("SELECT uid,name,pic_square FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1={0}) ORDER BY name ASC", "me()");

      this.FacebookClient.GetCompleted +=
          (o, e) =>
          {
            var result = (IDictionary<string, object>)e.GetResultData();
            data = (IList<object>)result["data"];
          };

      await this.FacebookClient.GetTaskAsync("me/friends");

      return (data ?? new List<object>());
    }
  }
}