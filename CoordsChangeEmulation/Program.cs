using System.Threading.Tasks;
using PickMeAppGlobal.Data.Repositories;

namespace CoordsChangeEmulation
{
  class Program
  {
    static void Main(string[] args)
    {
      var task = MainAsync();
      task.Wait();
    }

    static async Task MainAsync()
    {
      var historyRepository = new HistoryRepository();
      await historyRepository.MovePoints(25);
      historyRepository.Dispose();
    }
  }
}