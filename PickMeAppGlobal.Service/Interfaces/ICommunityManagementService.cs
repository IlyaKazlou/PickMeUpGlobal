
using System.Collections.Generic;
using System.Threading.Tasks;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Service.Interfaces
{
  public interface ICommunityManagementService
  {
    Task<List<OrganizationViewModel>> GetAllOrganizations();

    Task<List<OrganizationViewModel>> GetAllUserOrganizations(int userId);
  }
}