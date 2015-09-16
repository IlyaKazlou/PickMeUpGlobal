using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
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

    public ICommunityManagementRepository CommunityManagementRepository { get; set; }

    protected UserMapper UserMapper { get; set; }

    protected PointMapper PointMapper { get; set; }

    public UserService()
    {
      this.UserRepository = new UserRepository();
      this.CommunityManagementRepository = new CommunityManagementRepository();

      this.UserMapper = new UserMapper();
      this.PointMapper = new PointMapper();
    }

    public async Task<List<UserViewModel>> GetAllAsync()
    {
      return this.UserMapper.GetViewModelList(await this.UserRepository.GetAllAsync());
    }

    public async Task<UserViewModel> GetAsync(string userId, bool catchGroups = false)
    {
      if (catchGroups)
      {
        var user = await this.UserRepository.GetAsync(userId);
        var userGroups = await this.CommunityManagementRepository.GetAllUserGroups(user.Id);
        return this.UserMapper.GetViewModel(await this.UserRepository.GetAsync(userId), userGroups);
      }
      return this.UserMapper.GetViewModel(await this.UserRepository.GetAsync(userId));
    }

    public async Task<UserViewModel> GetAsync(Expression<Func<User, bool>> expr)
    {
      return this.UserMapper.GetViewModel(await this.UserRepository.GetAsync(expr));
    }

    public async Task<List<Point>> GetLatestPoints(string [] userIds)
    {
      return await this.UserRepository.GetLatestPoints(userIds);
    }

    public void AddGeolocationPointToUser(Point point)
    {
      this.UserRepository.AddGeolocationPointToUser(point);
    }

    public async Task<Point> GetLatestPoint(string userId)
    {
      return await this.UserRepository.GetLatestPoint(userId);
    }

    public List<PointViewModel> GetGeolocationPoints(User user, Func<Point, bool> expr = null)
    {
      return this.PointMapper.GetViewModelList(this.UserRepository.GetGeolocationPoints(user, expr));
    }

    public async Task<List<PointViewModel>> GetUserLocationHistory(string userId, DateTime? from, DateTime? to)
    {
      var points = await this.UserRepository.GetUserLocationHistory(userId, from, to);
      points = points.OrderBy(m => m.Date).ToList();
      return this.PointMapper.GetViewModelList(points);
    }

    public void AddUser(User user)
    {
      this.UserRepository.AddUser(user);
    }

    public void DeleteUser(string userId)
    {
      this.UserRepository.DeleteUser(userId);
    }

    public async Task<List<PointViewModel>> GetGeolocationPoints(string userId, Func<Point, bool> expr = null)
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