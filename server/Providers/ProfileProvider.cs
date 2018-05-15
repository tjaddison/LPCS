using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LPCS.Server.Core.Data;
using LPCS.Server.Data.Mongo;
using LPCS.Server.Data.Mongo.Entities;
using LPCS.Server.Providers.DomainModels;
using MongoDB.Driver;

namespace LPCS.Server.Providers
{
    public class ProfileProvider : IProfileProvider
    {
        private readonly LpcsMongoContext _context;
        private readonly AutoMapper.IMapper _mapper;

        public ProfileProvider(LpcsMongoContext context, AutoMapper.IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<ProfileListItemModel>> GetProfiles(ProfileListFilterModel filter, int page, int size)
        {
            PagedResult<ProfileListItemModel> result = null;

            var filterDefinition = Builders<Profile>.Filter.Ne(p=>p.Supervisor, null);
            filterDefinition = filterDefinition & Builders<Profile>.Filter.Eq(p=>p.Account.IsActive, true);
            filterDefinition = filterDefinition & Builders<Profile>.Filter.Eq(p=>p.Supervisor.IsActive, true);

            if(filter != null)
            {
                if(!string.IsNullOrEmpty(filter.ke))
                {
                    //filterDefinition = filterDefinition & Builders<Profile>.Filter.Text(filter.ke);

                    filterDefinition = filterDefinition & Builders<Profile>.Filter.Text(filter.ke, new TextSearchOptions{ CaseSensitive = false });
                    //var result = collection.Find(filter).ToList();
                }

                Action<Expression<Func<Profile, IEnumerable<string>>>, string[]> applyFilterDefinition = (fieldExpression, filterValue) => 
                {
                    if(filterValue?.Length > 0)
                    {
                        filterDefinition = filterDefinition & Builders<Profile>.Filter.AnyIn(fieldExpression, filterValue);
                    }
                };

                applyFilterDefinition(p => p.Supervisor.AgeSpecialties, filter.agSp);
                applyFilterDefinition(p => p.Supervisor.Ethnicities, filter.et);
                applyFilterDefinition(p => p.Supervisor.Events, filter.ev);
                applyFilterDefinition(p => p.Supervisor.Languages, filter.la);
                applyFilterDefinition(p => p.Supervisor.Modalities, filter.mo);
                applyFilterDefinition(p => p.Supervisor.Religions, filter.re);
                applyFilterDefinition(p => p.Supervisor.SpecialInterests, filter.spIn);
                applyFilterDefinition(p => p.Supervisor.Specialties, filter.sp);
                applyFilterDefinition(p => p.Supervisor.Treatments, filter.tr);
            }
            

            var cnt = await _context.Profiles.CountAsync(filterDefinition);
         
            var profiles = _context.Profiles.Find(
                filterDefinition: filterDefinition,
                pageIndex: page, 
                size: size, 
                isDescending: false, 
                order: p=>p.LastName);

            var items = _mapper.Map<IEnumerable<ProfileListItemModel>>(profiles);
            result = new PagedResult<ProfileListItemModel>(items, cnt);

            return result;





            // PagedResult<ProfileListItemModel> result = null;
            // Expression<Func<Profile, bool>> filter = p => p.Supervisor != null;
            // var cnt = await _context.Profiles.CountAsync(filter);
            // var profiles = _context.Profiles.Find(filter, p => p.LastName, page, size);
            // var items = _mapper.Map<IEnumerable<ProfileListItemModel>>(profiles);
            // result = new PagedResult<ProfileListItemModel>(items, cnt);
            // return result;
        }

        public ProfileModel GetProfileById(string id)
        {
            ProfileModel result = null;

            var entity = _context.Profiles.Get(id);
            result = _mapper.Map<ProfileModel>(entity);

            return result;
        }

        public async Task CreateProfile(ProfileModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = _mapper.Map<Profile>(model);
            await _context.Profiles.InsertAsync(entity);
        }

        private FilterDefinition<Profile> BuildFilter(ProfileListFilterModel model)
        {
            var filterDefinition = Builders<Profile>.Filter.Ne(p=>p.Supervisor, null);

            return filterDefinition;
        }
    }
}
