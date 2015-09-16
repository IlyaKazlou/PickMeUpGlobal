using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickMeAppGlobal.Data.Repositories;
using PickMeAppGlobal.Data.Repositories.Interfaces;
using PickMeAppGlobal.Service.Interfaces;
using PickMeAppGlobal.ViewModel.Mapping;
using PickMeAppGlobal.ViewModel.ViewModels;

namespace PickMeAppGlobal.Service
{
  public class CommunityManagementService : ICommunityManagementService
  {
    public ICommunityManagementRepository CommunityManagementRepository { get; set; }

    public IUserRepository UserRepository { get; set; }

    public CommunityMapper GroupMapper { get; set; }

    public UserMapper UserMapper { get; set; }

    public SubscriberMapper SubscriberMapper { get; set; }

    public CommunityManagementService()
    {
      this.CommunityManagementRepository = new CommunityManagementRepository();
      this.UserRepository = new UserRepository();
      this.UserMapper = new UserMapper();
      this.GroupMapper = new CommunityMapper();
      this.SubscriberMapper = new SubscriberMapper();
    }

    public async Task<List<GroupViewModel>> GetAllGroups()
    {
      var data = await this.CommunityManagementRepository.GetAllGroups();
      return this.GroupMapper.GetViewModelList(data);
    }

    public async Task<List<GroupViewModel>> GetAllUserGroups(string userId)
    {
      var data = await this.CommunityManagementRepository.GetAllUserGroups(userId);
      return this.GroupMapper.GetViewModelList(data);
    }

    public async Task<List<MetaTagViewModel>> GetGroupMetaTags(int groupId, int from, int to)
    {
      var tagViewModels = await this.CommunityManagementRepository.GetGroupMetaTags(groupId, from, to);
      return this.GroupMapper.GetMetaTagViewModels(tagViewModels);
    }

    public async Task<List<SubscriberViewModel>> GetGroupSubsctibers(int groupId, string[] tags, string conditionalOperator)
    {
      var result = new List<SubscriberViewModel>();
      var subscribers = await this.CommunityManagementRepository.GetGroupSubsctibers(groupId, tags, conditionalOperator);
      var ids = subscribers.Select(m => m.Id).ToArray();
      var latestPoints = await this.UserRepository.GetLatestPoints(ids);

      subscribers.ForEach(
        s =>
          {
            var vm = this.SubscriberMapper.GetViewModel(s, latestPoints.FirstOrDefault(m => m.UserId == s.Id));
            result.Add(vm);
          });

      return result;
    }
  }
}