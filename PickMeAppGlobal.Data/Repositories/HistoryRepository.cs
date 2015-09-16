using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data.Repositories.Interfaces;

namespace PickMeAppGlobal.Data.Repositories
{
  public class HistoryRepository : BaseRepository, IHistoryRepository
  {
    public async Task MovePoints(int diffInMin)
    {
      var now = DateTime.UtcNow;
      var points = await this.DbContext.Points.ToListAsync();
      var filteredPoints = points.Where(m => (now - m.Date).Minutes >= diffInMin).ToList();
      filteredPoints.ForEach(p => this.DbContext.PointHistories.Add(new PointHistory
      {
        Date = p.Date, UserId = p.UserId, Latitude = p.Latitude, Longitude = p.Longitude
      }));

      this.DbContext.Points.RemoveRange(filteredPoints);

      await this.SaveChangesAsync();
    }
  }
}