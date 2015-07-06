using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Core.Enumes;
using PickMeAppGlobal.Data.Repositories;
using PickMeAppGlobal.Data.Repositories.Interfaces;
using PickMeAppGlobal.Service.Interfaces;

namespace PickMeAppGlobal.Service
{
  public class UserService : BaseService, IUserService
  {
    protected IUserRepository UserRepository { get; set; }

    public UserService()
    {
      this.UserRepository = new UserRepository();
    }

    public async Task<List<User>> GetAllAsync()
    {
      return await this.UserRepository.GetAllAsync();
    }

    public async Task<User> GetAsync(Guid userId)
    {
      return await this.UserRepository.GetAsync(userId);
    }

    public List<Subscriber> GetSubscribers(User user, UserRoles targetUserRole)
    {
      return this.UserRepository.GetSubscribers(user, targetUserRole);
    }

    public void AddGeolocationPointToUser(Guid userId, Point point)
    {
      this.UserRepository.AddGeolocationPointToUser(userId, point);
    }

    public List<Point> GetGeolocationPoints(User user, Func<Point, bool> expr = null)
    {
      return this.UserRepository.GetGeolocationPoints(user, expr);
    }

    public void AddUser(User user)
    {
      this.UserRepository.AddUser(user);
    }

    public void DeleteUser(Guid userId)
    {
      this.UserRepository.DeleteUser(userId);
    }

    public async Task<List<Point>> GetGeolocationPoints(Guid userId, Func<Point, bool> expr = null)
    {
      var user = await this.UserRepository.GetAsync(userId);
      return this.GetGeolocationPoints(user, expr);
    }
  }
}