using System.Threading.Tasks;

namespace PickMeAppGlobal.Data.Repositories.Interfaces
{
  public interface IHistoryRepository
  {
    Task MovePoints(int diffInMin);
  }
}