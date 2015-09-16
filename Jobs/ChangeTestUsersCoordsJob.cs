using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.Service;

using Quartz;

namespace Jobs
{
  public class ChangeTestUsersCoordsJob : IJob
  {
    private Dictionary<string, UserCoordsChangeSchema> Info { get; set; }

    public ChangeTestUsersCoordsJob()
    {
      this.Info = new Dictionary<string, UserCoordsChangeSchema>
               {
                 { "Ilya", new UserCoordsChangeSchema
                             {
                               Radius = 1, StartLatitude = 54.7, StartLongitude = 27.7, Step = 0.006
                             }
                  },
                  { "Pavel", new UserCoordsChangeSchema
                             {
                               Radius = 1, StartLatitude = 54.6, StartLongitude = 27.8, Step = 0.009
                             }
                  },
                  { "Artsiom", new UserCoordsChangeSchema
                             {
                               Radius = 1, StartLatitude = 54.5, StartLongitude = 27.9, Step = 0.005
                             }
                  },
                  { "Petia", new UserCoordsChangeSchema
                             {
                               Radius = 1, StartLatitude = 54.4, StartLongitude = 28, Step = 0.01
                             }
                  },
                  { "Dima", new UserCoordsChangeSchema
                             {
                               Radius = 1, StartLatitude = 54.3, StartLongitude = 27.65, Step = 0.03
                             }
                  },
                  { "Andrey", new UserCoordsChangeSchema
                             {
                               Radius = 1, StartLatitude = 54.2, StartLongitude = 27.6, Step = 0.001
                             }
                  },
                  { "Jorge", new UserCoordsChangeSchema
                             {
                               Radius = 1, StartLatitude = 54.1, StartLongitude = 27.55, Step = 0.002
                             }
                  }
               };
    }

    public void Execute(IJobExecutionContext context)
    {
      Task[] tasks = new[]
      {
        this.MainAsync("Ilya"), this.MainAsync("Pavel"), this.MainAsync("Artsiom"), this.MainAsync("Petia"),
        this.MainAsync("Dima"), this.MainAsync("Andrey"), this.MainAsync("Jorge")
      };

      Task.WaitAll(tasks);
    }

    private async Task MainAsync(string name)
    {
      var userService = new UserService();
      var user = await userService.GetAsync(u => u.UserName == name);
      var latestPoint = await userService.GetLatestPoint(user.Id);

      if (latestPoint == null)
      {
        await AddPoint(userService, (decimal)this.Info[name].StartLongitude, (decimal)this.Info[name].StartLatitude, DateTime.UtcNow, user.Id);
        return;
      }

      var longi = latestPoint.Longitude + (decimal)this.Info[name].Step;
      var lat = latestPoint.Latitude + (decimal)this.Info[name].Step;

      if (longi > (decimal)this.Info[name].StartLongitude + 2)
      {
        longi = (decimal)this.Info[name].StartLongitude;
        lat = (decimal)this.Info[name].StartLatitude;
      }

      await AddPoint(userService, longi, lat, DateTime.UtcNow, user.Id);
    }

    static async Task AddPoint(UserService service, decimal lon, decimal lat, DateTime date, string userId)
    {
      var newPoint = new Point { Date = date, UserId = userId, Latitude = lat, Longitude = lon };
      service.AddGeolocationPointToUser(newPoint);

      await service.SaveChangesAsync();
      service.Dispose();
    }
  }
}