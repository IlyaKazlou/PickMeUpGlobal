
using System.Collections.Generic;
using System.Linq;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.Mapping.Base;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.ViewModel.Mapping
{
  public class CommunityMapper : BaseMapper<GroupViewModel, Group>
  {
    public override GroupViewModel GetViewModel(Group obj)
    {
      var viewModel = GetEmptyViewModel();
      if (obj != null)
      {
        viewModel.Name = obj.Name;
        viewModel.Id = obj.Id;
      }

      return viewModel;
    }

    public List<MetaTagViewModel> GetMetaTagViewModels(List<MetaTag> tags)
    {
      var result = tags.Select(t => new MetaTagViewModel { Name = t.Name, Defines = t.Defines, Description = t.Description }).ToList();
      return result;
    }
  }
}