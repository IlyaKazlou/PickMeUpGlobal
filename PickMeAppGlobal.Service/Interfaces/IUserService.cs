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

    Task<UserViewModel> GetAsync(string userId, bool catchGroups = false);

    void AddGeolocationPointToUser(Point point);

    List<PointViewModel> GetGeolocationPoints(User user, Func<Point, bool> expr = null);

    Task<List<PointViewModel>> GetUserLocationHistory(string userId, DateTime? from, DateTime? to);

    void AddUser(User user);

    void DeleteUser(string userId);
  }
}