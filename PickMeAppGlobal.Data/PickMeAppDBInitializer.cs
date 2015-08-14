using System;
using System.Collections.Generic;
using System.Data.Entity;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.Core.Enumes;
using PickMeAppGlobal.Core.Infrastructure;

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

      context.Organizations.AddRange(BuildOrganizationList());
      context.Clients.AddRange(BuildClientsList());

      context.SaveChanges();
    }

    private static List<Organization> BuildOrganizationList()
    {
      var organizationList = new List<Organization>
      {
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
        },
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
        }
      };

      return organizationList;
    }

    private static List<Client> BuildClientsList()
    {
      var clientsList = new List<Client> 
      {
          new Client
          { Id = "ngAuthApp", 
              Secret= Helper.GetHash("abc@123"), 
              Name="AngularJS front-end Application", 
              ApplicationType =  ApplicationTypes.JavaScript, 
              Active = true, 
              RefreshTokenLifeTime = 7200, 
              AllowedOrigin = "*"
          },
          new Client
          { Id = "consoleApp", 
              Secret=Helper.GetHash("123@abc"), 
              Name="Console Application", 
              ApplicationType = ApplicationTypes.NativeConfidential, 
              Active = true, 
              RefreshTokenLifeTime = 14400, 
              AllowedOrigin = "*"
          }
      };

      return clientsList;
    }
  }
}