using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.Core.Enumes;
using PickMeAppGlobal.Core.Infrastructure;
using PickMeAppGlobal.Data.Models;
using PickMeAppGlobal.Data.Repositories;

namespace PickMeAppGlobal.Data
{
  public class PickMeAppDbInitializer
  {
    private AuthRepository AuthRepository { get; set; }

    private List<UserAuthViewModel> TestUsers { get; set; }

    public async void Seed(PickMeAppContext context)
    {
      if (!context.Database.Exists() || context.ChangeTracker.HasChanges())
      {
        this.AuthRepository = new AuthRepository(context);
        this.TestUsers = this.BuildTestUserList();
        this.PopulateDb(context);
      }
    }

    private void PopulateDb(PickMeAppContext context)
    {
      this.CreateTestUsers();
      context.Groups.AddRange(BuildGroupList());
      context.Clients.AddRange(BuildClientsList());
      context.SaveChanges();

      this.AddUsersToGroup(context);
    }

    private void AddUsersToGroup(PickMeAppContext context)
    {
      var infos = this.GetUserGroupInfo();
      var targetGroup = context.Groups.FirstOrDefault(g => g.Name == "Epam Systems Inc");
      var targetInfos = infos.Where(i => i.Value.GroupId == targetGroup.Id);

      if(targetGroup == null) return;

      this.TestUsers.ForEach(u =>
        {
          var userGroupTags = targetInfos.First(i => i.Key == u.Email).Value.Tags;
          this.AddUserToGroup(targetGroup, u.Email, userGroupTags, context);
        });

      context.SaveChanges();
    }

    private void AddUserToGroup(Group group, string userEmail, string tags, PickMeAppContext context)
    {
      var user = context.Users.FirstOrDefault(u => u.Email == userEmail);

      if (user != null)
      {
        user.UserGroupInfos = user.UserGroupInfos ?? new List<UserGroupInfo>();
        user.UserGroupInfos.Add(new UserGroupInfo { GroupId = group.Id, UserId = user.Id, Tags = tags, Group = group });
      }
    }

    private void CreateTestUsers()
    {
      this.TestUsers.ForEach(u => this.AuthRepository.RegisterUser(u));
    }

    private List<UserAuthViewModel> BuildTestUserList()
    {
      var users = new List<UserAuthViewModel>
      {
        new UserAuthViewModel { UserName = "Ilya", Email = "ruzvelt.1992@tut.by", ConfirmPassword = "19920208", Password = "19920208", MetaTags = "N177,Nova Team"},
        new UserAuthViewModel { UserName = "Pavel", Email = "pavel.1995@tut.by", ConfirmPassword = "111111", Password = "111111", MetaTags = "N177,Nova Team" },
        new UserAuthViewModel { UserName = "Artsiom", Email = "rusak.1994@tut.by", ConfirmPassword = "111111", Password = "111111", MetaTags = "N177,Nova Team" },
        new UserAuthViewModel { UserName = "Dima", Email = "dimas.1992@tut.by", ConfirmPassword = "111111", Password = "111111", MetaTags = "Liberty" },
        new UserAuthViewModel { UserName = "Petia", Email = "petia.1989@tut.by", ConfirmPassword = "111111", Password = "111111", MetaTags = "Liberty" },
        new UserAuthViewModel { UserName = "Vasia", Email = "vasia.1991@tut.by", ConfirmPassword = "111111", Password = "111111", MetaTags = "Liberty" },
        new UserAuthViewModel { UserName = "Andrey", Email = "andrey.1987@tut.by", ConfirmPassword = "111111", Password = "111111", MetaTags = "K1-3,Liberty" },
        new UserAuthViewModel { UserName = "Sasha", Email = "sasha.1990@tut.by", ConfirmPassword = "111111", Password = "111111", TagConditionalOperator = "||", MetaTags = "K1-3,Liberty" },
        new UserAuthViewModel { UserName = "Jorge", Email = "jorge.1993@tut.by", ConfirmPassword = "111111", Password = "111111", TagConditionalOperator = "||" },
        new UserAuthViewModel { UserName = "Victoria", Email = "vicroria.1994@tut.by", ConfirmPassword = "111111", Password = "111111", TagConditionalOperator = "||" }
      };

      return users;
    }

    private Dictionary<string, UserGroupInfo> GetUserGroupInfo()
    {
      return new Dictionary<string, UserGroupInfo>
      {
        { "ruzvelt.1992@tut.by", new UserGroupInfo { GroupId = 1, Tags = "N177,Nova Team" } },
        { "pavel.1995@tut.by", new UserGroupInfo { GroupId = 1, Tags = "N177,Nova Team" } },
        { "rusak.1994@tut.by", new UserGroupInfo { GroupId = 1, Tags = "N177,Nova Team" } },
        { "dimas.1992@tut.by", new UserGroupInfo { GroupId = 1, Tags = "Liberty" } },
        { "petia.1989@tut.by", new UserGroupInfo { GroupId = 1, Tags = "Liberty" } },
        { "vasia.1991@tut.by", new UserGroupInfo { GroupId = 1, Tags = "Liberty" } },
        { "andrey.1987@tut.by", new UserGroupInfo { GroupId = 1, Tags = "K1-3,Liberty" } },
        { "sasha.1990@tut.by", new UserGroupInfo { GroupId = 1, Tags = "K1-3,Liberty" } },
        { "jorge.1993@tut.by", new UserGroupInfo { GroupId = 1, Tags = "" } },
        { "vicroria.1994@tut.by", new UserGroupInfo { GroupId = 1, Tags = "" } }
      };
    }

    private static List<Group> BuildGroupList()
    {
      var organizationList = new List<Group>
      {
        new Group
        {
          CreatedDate = DateTime.Now,
          LastUpdatedDate = DateTime.Now,
          Name = "Epam Systems Inc",
          MetaTags = new List<MetaTag>
          {
            new MetaTag { Name = "N177", Defines = "Office" },
            new MetaTag { Name = "K1-3", Defines = "Office" },
            new MetaTag { Name = "Nova Team", Defines = "Team"},
            new MetaTag { Name = "Liberty", Defines = "Team"},
            new MetaTag { Name = "Epam Tennis Club", Defines = "Сommunity"},
            new MetaTag { Name = "Epam Minsk", Defines = "Region" },
            new MetaTag { Name = "Epam Yoga", Defines = "Community" },
            new MetaTag { Name = "Epam Summer Party 2016", Defines = "Event" }
          }
        },
        new Group
        {
          CreatedDate = DateTime.Now,
          LastUpdatedDate = DateTime.Now,
          Name = "Бел Амкодор",
          MetaTags = new List<MetaTag> { new MetaTag { Name = "Отдел Эксплуатации", Defines = "Unit"} }
        },
        new Group
        {
          CreatedDate = DateTime.Now,
          LastUpdatedDate = DateTime.Now,
          Name = "Поездка на меловые карьеры"
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