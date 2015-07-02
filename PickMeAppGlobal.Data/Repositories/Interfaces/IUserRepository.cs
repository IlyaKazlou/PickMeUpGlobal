using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickMeAppGlobal.Core;
using PickMeAppGlobal.Core.Enumes;

namespace PickMeAppGlobal.Data.Repositories.Interfaces
{
  public interface IUserRepository
  {
    Task<List<User>> GetAllAsync();

    Task<User> GetAsync(Guid userId);

    List<Subscriber> GetSubscribers(User user, UserRoles targetUserRole);

    void AddUser(User user);

    void UpdateUser(User user);

    void DeleteUser(Guid userId);

    void SaveChangesAsync();
  }
}