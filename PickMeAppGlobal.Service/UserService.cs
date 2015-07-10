using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Core.Enumes;
using PickMeAppGlobal.Data.Repositories;
using PickMeAppGlobal.Data.Repositories.Interfaces;
using PickMeAppGlobal.Service.Interfaces;
using PickMeAppGlobal.ViewModel.Mapping;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Service
{
  public class UserService : IUserService
  {
    public IUserRepository UserRepository { get; set; }

    protected UserMapper UserMapper { get; set; }

    protected SubscriberMapper SubscriberMapper { get; set; }

    protected PointMapper PointMapper { get; set; }

    public UserService()
    {
      this.UserRepository = new UserRepository();

      this.UserMapper = new UserMapper();
      this.SubscriberMapper = new SubscriberMapper();
      this.PointMapper = new PointMapper();
    }

    public async Task<List<UserViewModel>> GetAllAsync()
    {
      return this.UserMapper.GetViewModelList(await this.UserRepository.GetAllAsync());
    }

    public async Task<UserViewModel> GetAsync(Guid userId)
    {
      return this.UserMapper.GetViewModel(await this.UserRepository.GetAsync(userId));
    }

    public async Task<List<SubscriberViewModel>> GetSubscribers(Guid userId, string targetUserRole)
    {
      var subscribers = await this.UserRepository.GetSubscribers(userId, targetUserRole);
      var userIds = subscribers.Select(s => s.SubscriberUserId).ToArray();
      var latestPoints = await this.UserRepository.GetLatestPoints(userIds);
      var viewModels = this.SubscriberMapper.GetViewModelList(subscribers, latestPoints);
      return viewModels;
    }

    public void AddGeolocationPointToUser(Point point)
    {
      this.UserRepository.AddGeolocationPointToUser(point);
    }

    public async Task<Point> GetLatestPoint(Guid userId)
    {
      return await this.UserRepository.GetLatestPoint(userId);
    }

    public List<PointViewModel> GetGeolocationPoints(User user, Func<Point, bool> expr = null)
    {
      return this.PointMapper.GetViewModelList(this.UserRepository.GetGeolocationPoints(user, expr));
    }

    public void AddUser(User user)
    {
      this.UserRepository.AddUser(user);
    }

    public void DeleteUser(Guid userId)
    {
      this.UserRepository.DeleteUser(userId);
    }

    public async Task<List<PointViewModel>> GetGeolocationPoints(Guid userId, Func<Point, bool> expr = null)
    {
      var user = await this.UserRepository.GetAsync(userId);
      return this.GetGeolocationPoints(user, expr);
    }

    public void Dispose()
    {
      this.UserRepository.Dispose();
    }

    public async Task SaveChangesAsync()
    {
      await this.UserRepository.SaveChangesAsync();
    }
  }
}