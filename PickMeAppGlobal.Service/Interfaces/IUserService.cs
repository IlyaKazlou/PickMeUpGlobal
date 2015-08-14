using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Service.Interfaces
{
  public interface IUserService : IService
  {
    Task<List<PointViewModel>> GetGeolocationPoints(string userId, Func<Point, bool> expr = null);

    Task<List<UserViewModel>> GetAllAsync();

    Task<UserViewModel> GetAsync(string userId);

    Task<List<SubscriberViewModel>> GetSubscribers(string userId, string targetUserRole);

    void AddGeolocationPointToUser(Point point);

    List<PointViewModel> GetGeolocationPoints(User user, Func<Point, bool> expr = null);

    void AddUser(User user);

    void DeleteUser(string userId);
  }
}