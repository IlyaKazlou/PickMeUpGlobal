using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data.Repositories
{
  public class UserRepository
  {
    public PickMeAppContext DbContext { get; set; }
    private DbSet<User> DbSet { get; set; }

    public UserRepository()
    {
      this.DbContext = new PickMeAppContext();
      this.DbSet = this.DbContext.Users;
    }

    public async Task<List<User>> GetAll()
    {
      return await this.DbSet.ToListAsync();
    }

    public async Task<User> GetUser(Guid id)
    {
      return await this.DbSet.FirstOrDefaultAsync(m => m.Id == id);
    }
  }
}