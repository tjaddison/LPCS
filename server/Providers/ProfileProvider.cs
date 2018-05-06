using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
// using AutoMapper;
using LPCS.Server.Core.Data;
using LPCS.Server.Data.Mongo;
using LPCS.Server.Data.Mongo.Entities;
using LPCS.Server.Providers.DomainModels;

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

        public async Task<PagedResult<ProfileListItemModel>> GetProfiles(int page, int size)
        {
            PagedResult<ProfileListItemModel> result = null;
            Expression<Func<Profile, bool>> filter = p => p.Supervisor != null;
            var cnt = await _context.Profiles.CountAsync(filter);
            var profiles = _context.Profiles.Find(filter, p => p.LastName, page, size);
            var items = _mapper.Map<IEnumerable<ProfileListItemModel>>(profiles);
            result = new PagedResult<ProfileListItemModel>(items, cnt);
            return result;
        }

        public ProfileModel GetProfileById(string id)
        {
            ProfileModel result = null;

            var entity = _context.Profiles.Get(id);
            result = _mapper.Map<ProfileModel>(entity);

            return result;
        }

        public async Task SaveProfile(ProfileModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = _mapper.Map<Profile>(model);
            await _context.Profiles.InsertAsync(entity);
        }
    }
}
