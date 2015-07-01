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

      var users = await this.Repository.GetAllAsync();
      var user = users.First(m => m.Name == "Ilya Kazlou1");
      var subscribers = user.Subscribers;

      return View();
    }
  }
}