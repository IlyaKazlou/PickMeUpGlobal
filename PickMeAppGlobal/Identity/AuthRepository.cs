using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using PickMeAppGlobal.Core;
using PickMeAppGlobal.Data;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Identity
{

  public class AuthRepository : IDisposable
  {
    private readonly PickMeAppContext _ctx;

    private readonly UserManager<User> _userManager;

    public AuthRepository()
    {
      this._ctx = new PickMeAppContext();
      this._userManager = new UserManager<User>(new UserStore<User>(this._ctx));
    }

    public async Task<IdentityResult> RegisterUser(UserAuthViewModel userModel)
    {
      User user = new User
      {
        UserName = userModel.UserName,
        Email = userModel.Email
      };

      var result = await this._userManager.CreateAsync(user, userModel.Password);

      return result;
    }

    public async Task<User> FindUser(string email, string password)
    {
      var user = await this._userManager.FindByEmailAsync(email);

      if (!await this._userManager.CheckPasswordAsync(user, password))
      {
        return null;
      }

      return user;
    }

    public Client FindClient(string clientId)
    {
      var client = this._ctx.Clients.Find(clientId);

      return client;
    }

    public async Task<bool> AddRefreshToken(RefreshToken token)
    {

      var existingToken = this._ctx.RefreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

      if (existingToken != null)
      {
        var result = await RemoveRefreshToken(existingToken);
      }

      this._ctx.RefreshTokens.Add(token);

      return await this._ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveRefreshToken(string refreshTokenId)
    {
      var refreshToken = await this._ctx.RefreshTokens.FindAsync(refreshTokenId);

      if (refreshToken != null)
      {
        this._ctx.RefreshTokens.Remove(refreshToken);
        return await this._ctx.SaveChangesAsync() > 0;
      }

      return false;
    }

    public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
    {
      this._ctx.RefreshTokens.Remove(refreshToken);
      return await this._ctx.SaveChangesAsync() > 0;
    }

    public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
    {
      var refreshToken = await this._ctx.RefreshTokens.FindAsync(refreshTokenId);

      return refreshToken;
    }

    public List<RefreshToken> GetAllRefreshTokens()
    {
      return this._ctx.RefreshTokens.ToList();
    }

    public async Task<User> FindAsync(UserLoginInfo loginInfo)
    {
      User user = await this._userManager.FindAsync(loginInfo);

      return user;
    }

    public async Task<IdentityResult> CreateAsync(User user)
    {
      var result = await this._userManager.CreateAsync(user);

      return result;
    }

    public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
    {
      var result = await this._userManager.AddLoginAsync(userId, login);

      return result;
    }

    public void Dispose()
    {
      this._ctx.Dispose();
      this._userManager.Dispose();

    }
  }
}