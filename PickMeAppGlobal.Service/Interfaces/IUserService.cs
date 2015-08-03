using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Service.Interfaces
{
  public interface IUserService : IService
  {
    Task<List<PointViewModel>> GetGeolocationPoints(int userId, Func<Point, bool> expr = null);

    Task<List<UserViewModel>> GetAllAsync();

    Task<UserViewModel> GetAsync(int userId);

    Task<List<SubscriberViewModel>> GetSubscribers(int userId, string targetUserRole);

    void AddGeolocationPointToUser(Point point);

    List<PointViewModel> GetGeolocationPoints(User user, Func<Point, bool> expr = null);

    void AddUser(User user);

    void DeleteUser(int userId);
  }
}