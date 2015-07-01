using System;
using System.Collections.Generic;
using System.Data.Entity;

using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data
{
  public class PickMeAppDbInitializer : DropCreateDatabaseAlways<PickMeAppContext>
  {
    protected override void Seed(PickMeAppContext context)
    {
      base.Seed(context);
      this.PopulateDb(context);
    }

    private void PopulateDb(PickMeAppContext context)
    {
      var user1 = new User
      {
        DriverHubName = "IlyaKazlou_1_Driver",
        PassengerHubName = "IlyaKazlou_1_Passanger",
        Name = "Ilya Kazlou1",
        Id = Guid.NewGuid()
      };

      var user2 = new User
      {
        DriverHubName = "IlyaKazlou2_2_Driver",
        PassengerHubName = "IlyaKazlou2_2_Passanger",
        Name = "Ilya Kazlou2",
        Id = Guid.NewGuid()
      };

      var user3 = new User
      {
        DriverHubName = "IlyaKazlou3_3_Driver",
        PassengerHubName = "IlyaKazlou3_3_Passanger",
        Name = "Ilya Kazlou3",
        Id = Guid.NewGuid()
      };

      user1.Subscribers = new List<Subscriber>
      {
        new Subscriber { HubName = "IlyaKazlou_1_Driver", HubType = "Driver", UserId = user1.Id, SubscriberUserId = user2.Id },
        new Subscriber { HubName = "IlyaKazlou_1_Driver", HubType = "Driver", UserId = user1.Id, SubscriberUserId = user3.Id }
      };

      context.Users.AddRange(new[] { user1, user2, user3 });
      context.SaveChanges();
    }
  }
}