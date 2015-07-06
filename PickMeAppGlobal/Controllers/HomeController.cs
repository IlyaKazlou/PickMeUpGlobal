using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

using PickMeAppGlobal.Data.Repositories;

namespace PickMeAppGlobal.Controllers
{
  public class HomeController : Controller
  {
    public UserRepository Repository { get; set; }

    public HomeController()
    {
      this.Repository = new UserRepository();
    }

    public async Task<ActionResult> Index()
    {
      ViewBag.Title = "Home Page";

      this.Repository.DeleteUser(new Guid("B64F5F0D-9419-45F6-ADD8-30F5724E0C49"));
      await this.Repository.SaveChangesAsync();

      return View();
    }
  }
}