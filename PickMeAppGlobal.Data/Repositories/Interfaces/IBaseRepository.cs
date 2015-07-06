using System;
using System.Threading.Tasks;

namespace PickMeAppGlobal.Data.Repositories.Interfaces
{
  public interface IBaseRepository : IDisposable
  {
    Task SaveChangesAsync();
  }
}