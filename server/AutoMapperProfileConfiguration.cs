using System.Collections.Generic;
using AutoMapper;
using LPCS.Server.Data.Mongo.Entities;
using LPCS.Server.Providers.DomainModels;

namespace LPCS.Server
{
    public class AutoMapperProfileConfiguration : AutoMapper.Profile
    {
        public AutoMapperProfileConfiguration()
        : this("AppProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<ProfileModel, Data.Mongo.Entities.Profile>();
             CreateMap<LogModel, Log>();
            //CreateMap<IEnumerable<ProfileListItemModel>, IEnumerable<Profile>>();
        }
    }
}
