using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

using PickMeAppGlobal.Data.Models;
using PickMeAppGlobal.Data.Repositories;
using PickMeAppGlobal.Results;

namespace PickMeAppGlobal.Controllers
{
  [Authorize]
  [RoutePrefix("api/Account")]
  public class AccountController : ApiController
  {
    private readonly AuthRepository _repo = null;

    public AccountController()
    {
      _repo = new AuthRepository();
    }

    // POST api/Account/Register
    [AllowAnonymous]
    [Route("Register")]
    public async Task<IHttpActionResult> Register(UserAuthViewModel userModel)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IdentityResult result = await _repo.RegisterUserAsync(userModel);

      IHttpActionResult errorResult = this.GetErrorResult(result);

      if (errorResult != null)
      {
        return errorResult;
      }

      return Ok();
    }

    // GET api/Account/ExternalLogin
    [OverrideAuthentication]
    [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
    [AllowAnonymous]
    [Route("ExternalLogin", Name = "ExternalLogin")]
    public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
    {
      string redirectUri = string.Empty;

      if (error != null)
      {
        return BadRequest(Uri.EscapeDataString(error));
      }

      if (!User.Identity.IsAuthenticated)
      {
        return new ChallengeResult(provider, this);
      }

      var redirectUriValidationResult = this.ValidateClientAndRedirectUri(this.Request, ref redirectUri);

      if (!string.IsNullOrWhiteSpace(redirectUriValidationResult))
      {
        return BadRequest(redirectUriValidationResult);
      }

      var externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

      if (externalLogin == null)
      {
        return InternalServerError();
      }

      if (externalLogin.LoginProvider != provider)
      {
        Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        return new ChallengeResult(provider, this);
      }

      redirectUri = string.Format("{0}#external_access_token={1}&provider={2}&haslocalaccount={3}&external_user_name={4}",
                                      redirectUri,
                                      externalLogin.ExternalAccessToken,
                                      externalLogin.LoginProvider,
                                      true,
                                      externalLogin.UserName);

      return Redirect(redirectUri);
    }

    private IAuthenticationManager Authentication
    {
      get { return Request.GetOwinContext().Authentication; }
    }

    private class ExternalLoginData
    {
      public string LoginProvider { get; set; }
      public string ProviderKey { get; set; }
      public string UserName { get; set; }
      public string ExternalAccessToken { get; set; }

      public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
      {
        if (identity == null)
        {
          return null;
        }

        Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

        if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer) || String.IsNullOrEmpty(providerKeyClaim.Value))
        {
          return null;
        }

        if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
        {
          return null;
        }

        return new ExternalLoginData
        {
          LoginProvider = providerKeyClaim.Issuer,
          ProviderKey = providerKeyClaim.Value,
          UserName = identity.FindFirstValue(ClaimTypes.Name),
          ExternalAccessToken = identity.FindFirstValue("ExternalAccessToken")
        };
      }
    }

    private string ValidateClientAndRedirectUri(HttpRequestMessage request, ref string redirectUriOutput)
    {

      Uri redirectUri;

      var redirectUriString = GetQueryString(Request, "redirect_uri");

      if (string.IsNullOrWhiteSpace(redirectUriString))
      {
        return "redirect_uri is required";
      }

      bool validUri = Uri.TryCreate(redirectUriString, UriKind.Absolute, out redirectUri);

      if (!validUri)
      {
        return "redirect_uri is invalid";
      }

      redirectUriOutput = redirectUri.AbsoluteUri;

      return string.Empty;
    }

    private string GetQueryString(HttpRequestMessage request, string key)
    {
      var queryStrings = request.GetQueryNameValuePairs();

      if (queryStrings == null) return null;

      var match = queryStrings.FirstOrDefault(keyValue => string.Compare(keyValue.Key, key, true) == 0);

      if (string.IsNullOrEmpty(match.Value)) return null;

      return match.Value;
    }

    private IHttpActionResult GetErrorResult(IdentityResult result)
    {
      if (result == null)
      {
        return InternalServerError();
      }

      if (!result.Succeeded)
      {
        if (result.Errors != null)
        {
          foreach (string error in result.Errors)
          {
            ModelState.AddModelError("", error);
          }
        }

        if (ModelState.IsValid)
        {
          // No ModelState errors are available to send, so just return an empty BadRequest.
          return BadRequest();
        }

        return BadRequest(ModelState);
      }

      return null;
    }
  }
}