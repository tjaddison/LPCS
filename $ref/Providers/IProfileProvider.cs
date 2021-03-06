﻿using System.Threading.Tasks;
using LPCS.Server.Core.Data;
using LPCS.Server.Providers.DomainModels;

namespace LPCS.Server.Providers
{
    public interface IProfileProvider
    {
        Task<PagedResult<ProfileListItemModel>> GetProfiles(ProfileListFilterModel filter, int page, int size);
        ProfileModel GetProfileById(string id);
        Task CreateProfile(ProfileModel model);
        Task<ProfileFilterModel> GetProfileFilter(ProfileListFilterModel filter, int page, int size);
    }
}
