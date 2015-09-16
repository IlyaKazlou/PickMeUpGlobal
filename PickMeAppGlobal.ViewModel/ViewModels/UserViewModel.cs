
namespace PickMeAppGlobal.ViewModel.ViewModels
{
  public class UserViewModel : IViewModel
  {
    public string UserName { get; set; }

    public string SecondName { get; set; }

    public string CurrentRole { get; set; }

    public string[] Groups { get; set; }

    public string CoverPhoto { get; set; }

    public string Id { get; set; }
  }
}