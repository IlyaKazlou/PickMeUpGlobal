using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Repositories;
using PickMeAppGlobal.Data.Repositories.Interfaces;
using PickMeAppGlobal.Service.Interfaces;
using PickMeAppGlobal.ViewModel.Mapping;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Service
{
  public class CommunityManagementService : ICommunityManagementService
  {
    public ICommunityManagementRepository CommunityManagementRepository { get; set; }

    public CommunityMapper OrganizationMapper { get; set; }

    public CommunityManagementService()
    {
      this.CommunityManagementRepository = new CommunityManagementRepository();
      this.OrganizationMapper = new CommunityMapper();
    }

    public async Task<List<OrganizationViewModel>> GetAllOrganizations()
    {
      var data = await this.CommunityManagementRepository.GetAllOrganizations();
      return this.OrganizationMapper.GetViewModelList(data);
    }

    public async Task<List<OrganizationViewModel>> GetAllUserOrganizations(int userId)
    {
      var data = await this.CommunityManagementRepository.GetAllUserOrganizations(userId);
      return this.OrganizationMapper.GetViewModelList(data);
    }
  }
}