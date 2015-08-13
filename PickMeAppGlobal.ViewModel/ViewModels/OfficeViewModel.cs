
using System.Collections.Generic;

namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class OfficeViewModel : IViewModel
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int OrganizationId { get; set; }

    public virtual List<GroupViewModel> Groups { get; set; }
  }
}