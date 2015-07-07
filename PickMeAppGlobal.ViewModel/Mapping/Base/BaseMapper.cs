using System.Collections.Generic;
using System.Linq;

using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.ViewModel.Mapping.Base
{
  public abstract class BaseMapper<TViewModel, TEntity> : IMapper<TViewModel, TEntity>
      where TViewModel : class,IViewModel, new()
  {
    #region IMapper<TViewModel,TEntity> Members

    public abstract TViewModel GetViewModel(TEntity obj);

    public virtual TEntity GetObject(TViewModel viewModel)
    {
      return default(TEntity);
    }

    protected virtual TViewModel GetEmptyViewModel()
    {
      return (new TViewModel());
    }

    public virtual List<TViewModel> GetViewModelList(List<TEntity> list)
    {
      var vml = new List<TViewModel>();
      if (list != null && list.Any())
        vml.AddRange(list.Select(this.GetViewModel));
      return vml;
    }

    #endregion
  }
}