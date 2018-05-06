using System.Threading.Tasks;
using LPCS.Server.Core.Data;
using LPCS.Server.Providers.DomainModels;

namespace LPCS.Server.Providers
{
    public interface IProfileProvider
    {
        Task<PagedResult<ProfileListItemModel>> GetProfiles(int page, int size);
        ProfileModel GetProfileById(string id);
        Task SaveProfile(ProfileModel model);
    }
}
