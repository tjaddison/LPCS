using System.Collections.Generic;
using AutoMapper;
using LPCS.Server.Providers.DomainModels;

namespace LPCS.Server
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("AppProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<ProfileModel, Profile>();
            //CreateMap<IEnumerable<ProfileListItemModel>, IEnumerable<Profile>>();
        }
    }
}
