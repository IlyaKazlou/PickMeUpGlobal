using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data.Repositories.Interfaces
{
  public interface ICommunityManagementRepository
  {
    Task<List<Organization>> GetAllOrganizations();

    Task<List<Organization>> GetAllUserOrganizations(int userId);
  }
}