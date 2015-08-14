using System;
using System.Collections.Generic;

namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class OrganizationViewModel : IViewModel
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public string CreatorId { get; set; }

    public virtual List<OfficeViewModel> Offices { get; set; }
  }
}