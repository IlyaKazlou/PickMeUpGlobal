using System;
using System.Collections.Generic;
using System.Data.Entity;

using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data
{
  public class PickMeAppDbInitializer : DropCreateDatabaseIfModelChanges<PickMeAppContext>
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
        Name = "Ilya Kazlou1",
        Id = 1
      };

      var user2 = new User
      {
        Name = "Ilya Kazlou2",
        Id = 2
      };

      var user3 = new User
      {
        Name = "Ilya Kazlou3",
        Id = 3
      };

      context.Organizations.Add(
        new Organization
          {
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Epam Systems Inc",
            Offices = new List<Office> { 
              new Office { 
                Name = "Куприевича 1", Latitude = (decimal)28.422, Longitude = (decimal)-81.578,
                Groups = new List<Group>
                {
                  new Group { Name = "Nova Team"}, new Group { Name = "Inspiration Team"}
                }
              }
            }
          });

      context.Organizations.Add(
        new Organization
        {
          CreatedDate = DateTime.Now,
          LastUpdatedDate = DateTime.Now,
          Name = "Бел Амкодор",
          Offices = new List<Office> { 
              new Office { 
                Name = "Заводская 37", Latitude = (decimal)27, Longitude = (decimal)-79,
                Groups = new List<Group>
                {
                  new Group { Name = "Отдел эксплуатации и обслуживания"}, new Group { Name = "Отдел контроля качества"}
                }
              }
            }
        });

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