using System.Collections.Generic;
using System.Linq;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.Mapping.Base;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.ViewModel.Mapping
{
  public class UserMapper : BaseMapper<UserViewModel, User>
  {

    public override UserViewModel GetViewModel(User obj)
    {
      var viewModel = GetEmptyViewModel();
      if (obj != null)
      {
        viewModel.UserName = obj.UserName;
        viewModel.CurrentRole = obj.CurrentUserRole;
        viewModel.Id = obj.Id;
      }
      return viewModel;
    }

    public UserViewModel GetViewModel(User obj, List<Group> userGroups)
    {
      var viewModel = this.GetViewModel(obj);
      viewModel.Groups = userGroups.Select(g => g.Name).ToArray();
      return viewModel;
    }
  }
}