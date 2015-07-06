using System.Threading.Tasks;
using PickMeAppGlobal.Data.Repositories.Interfaces;
using PickMeAppGlobal.Service.Interfaces;

namespace PickMeAppGlobal.Service
{
  public class BaseService : IService
  {
    protected IBaseRepository BaseRepository { get; set; }

    public void Dispose()
    {
      this.BaseRepository.Dispose();
    }

    public async Task SaveChangesAsync()
    {
      await this.BaseRepository.SaveChangesAsync();
    }
  }
}