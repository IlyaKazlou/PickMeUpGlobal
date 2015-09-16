using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace PickMeAppGlobal.signalr.hubs
{
  [HubName("UserStateChangeHub")]
  public class UserStateChangeHub : Hub
  {
    public void BrodcastLatestPointToSubscribers(string id, decimal lat, decimal lon)
    {
      try
      {
        var groups = Clients.Caller.Groups;
        var groupCount = groups.Count;
        for (var i = 0; i < groupCount; i++)
        {
          var groupName = groups[i] as string;
          if (!string.IsNullOrEmpty(groupName))
            Clients.Group(groupName).updateLatestPoint(lat, lon);
        }
      }
      catch (Exception err)
      {
        // log error;
      }
    }

    public Task Join(string groupName)
    {
      return Groups.Add(Context.ConnectionId, groupName);
    }

    public Task GroupLeave(string groupName)
    {
      return Groups.Remove(Context.ConnectionId, groupName);
    }
  }
}