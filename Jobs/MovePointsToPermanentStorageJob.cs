using System.Threading.Tasks;
using PickMeAppGlobal.Data.Repositories;
using PickMeAppGlobal.Data.Repositories.Interfaces;

using Quartz;

namespace Jobs
{
  public class MovePointsToPermanentStorageJob : IJob
  {
    protected IHistoryRepository HistoryRepository { get; set; }

    public MovePointsToPermanentStorageJob()
    {
      this.HistoryRepository = new HistoryRepository();
    }

    public void Execute(IJobExecutionContext context)
    {
      var task = this.MainAsync();
      task.Wait();
    }

    private async Task MainAsync()
    {
      await this.HistoryRepository.MovePoints(25);
    }
  }
}