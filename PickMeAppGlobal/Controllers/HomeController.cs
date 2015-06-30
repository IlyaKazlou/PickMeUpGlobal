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

      var users = await this.Repository.GetAll();

      return View();
    }
  }
}