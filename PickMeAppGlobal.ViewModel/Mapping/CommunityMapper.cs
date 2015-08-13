
using System.Collections.Generic;
using System.Linq;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.Mapping.Base;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.ViewModel.Mapping
{
  public class CommunityMapper : BaseMapper<OrganizationViewModel, Organization>
  {
    public override OrganizationViewModel GetViewModel(Organization obj)
    {
      var viewModel = GetEmptyViewModel();
      if (obj != null)
      {
        viewModel.CreatedDate = obj.CreatedDate;
        viewModel.CreatorId = obj.CreatorId;
        viewModel.Id = obj.Id;
        viewModel.LastUpdatedDate = obj.LastUpdatedDate;
        viewModel.Name = obj.Name;
        viewModel.Offices = this.GetOfficeViewModels(obj.Offices);
      }

      return viewModel;
    }

    private List<OfficeViewModel> GetOfficeViewModels(List<Office> offices)
    {
      return offices.Select(o => new OfficeViewModel
      {
        Id = o.Id,
        Latitude = o.Latitude,
        Longitude = o.Longitude,
        Name = o.Name,
        OrganizationId = o.OrganizationId,
        Groups = this.GetGroupViewModels(o.Groups)
      }).ToList();
    }

    private List<GroupViewModel> GetGroupViewModels(List<Group> groups)
    {
      return groups.Select(o => new GroupViewModel()
      {
        Name = o.Name,
        Id = o.Id,
        OfficeId = o.OfficeId
      }).ToList();
    }
  }
}