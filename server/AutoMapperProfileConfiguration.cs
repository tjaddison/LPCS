using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using LPCS.Server.Data.Mongo.Entities;
using LPCS.Server.Providers.DomainModels;
using dme = LPCS.Server.Data.Mongo.Entities;
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
            CreateMap<ProfileModel, dme.Profile>();
            CreateMap<LogModel, Log>();
            CreateMap<dme.Profile, ProfileListItemModel>()
                .ForMember(dest => dest.Blurb, opts => opts.MapFrom(src => src.Supervisor.UniqueDescription))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.Supervisor.Addresses.Where(a => a.Type.Equals("Primary")).FirstOrDefault().City)) 
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.Supervisor.Addresses.Where(a => a.Type.Equals("Primary")).FirstOrDefault().State)) 
                .ForMember(dest => dest.Subtitle, opts => opts.MapFrom(src => $"{src.Supervisor.TherapistType}{(string.IsNullOrEmpty(src.Supervisor.TherapistType) ? "" : ", ")}{string.Join(", ", src.Supervisor.CredentialInitials)}".Trim()))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Supervisor.UseBusinessNameForListing == true ? src.Supervisor.BusinessName : $"{(string.IsNullOrEmpty(src.TitleType) ? "" : $"{src.TitleType}. ")}{src.FirstName}{(string.IsNullOrEmpty(src.MiddleName) ? "" : $" {src.MiddleName}.")} {src.LastName}"))
                .ForMember(dest => dest.Zip, opts => opts.MapFrom(src => src.Supervisor.Addresses.Where(a => a.Type.Equals("Primary")).FirstOrDefault().Zip));  
                
        }
    }
}
