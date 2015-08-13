using System;
using System.Net.Http;

using AzureNotificationHub;

using Microsoft.Azure.NotificationHubs;

namespace PickMeAppGlobal.Service
{
  public class HubManagementService
  {
    public const string HubNamespace = "pickmeupmobilehub-ns";

    private NotificationHubClient hub;

    public void CreateHub(string hubName)
    {
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(String.Format("https://{0}.servicebus.windows.net/{1}?api-version=2015-01", HubNamespace, hubName));
      }
    }
  }
}