using System.Threading.Tasks;
using PickMeAppGlobal.Data.Repositories.Interfaces;

namespace PickMeAppGlobal.Data.Repositories
{
  public class BaseRepository : IBaseRepository
  {
    protected PickMeAppContext DbContext { get; set; }

    public BaseRepository()
    {
      this.DbContext = new PickMeAppContext();
    }

    public async Task SaveChangesAsync()
    {
      await this.DbContext.SaveChangesAsync();
    }

    public virtual void Dispose()
    {
      this.DbContext.Dispose();
    }
  }
}