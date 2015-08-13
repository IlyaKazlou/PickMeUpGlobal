using System.Collections.Generic;
using System.Threading.Tasks;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Service.Interfaces
{
  public interface ISocialNetworkService
  {
    Task<UserViewModel> GetMe();

    Task<IList<object>> GetFriends();
  }
}