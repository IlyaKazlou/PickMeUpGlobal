using System.Collections.Generic;

using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.ViewModel.Mapping.Base
{
  public interface IMapper<TViewModel, TEntity>
      where TViewModel : class, IViewModel
  {
    TViewModel GetViewModel(TEntity obj);
    TEntity GetObject(TViewModel viewModel);
    List<TViewModel> GetViewModelList(List<TEntity> list);
  }
}