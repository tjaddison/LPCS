using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LPCS.Server.Core.Data;
using LPCS.Server.Data.Mongo;
using LPCS.Server.Data.Mongo.Entities;
using LPCS.Server.Providers.DomainModels;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Text.RegularExpressions;
using MongoDB.Driver.GeoJsonObjectModel;

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

            var filterDefinition = CreateFilterDefinition(filter);          

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

        public async Task<ProfileFilterModel> GetProfileFilter(ProfileListFilterModel filter, int page, int size)
        {
            var filterDefinition = CreateFilterDefinition(filter);  
            ProfileFilterModel result = new ProfileFilterModel();

            Func<Expression<Func<Profile, object>>,string,Task> buildFilterCounts = async (field, attributeName) => 
            {
                var counts = new SortedDictionary<string,int>();

                await _context.Profiles.Collection.Aggregate()
                    .Match(filterDefinition)
                    .Unwind(field)                    
                    .Group(new BsonDocument { { "_id", $"$Supervisor.{Regex.Replace(attributeName, @"\s+", "")}" }, { "count", new BsonDocument("$sum", 1) } })
                    .ForEachAsync(item => {
                        counts.Add(item.GetValue("_id").ToString(), item.GetValue("count").ToInt32());
                    });

                result.Add(attributeName, counts);
            };

            await buildFilterCounts(p => p.Supervisor.AgeSpecialties, "Age Specialties");
            await buildFilterCounts(p => p.Supervisor.Ethnicities, "Ethnicities");
            await buildFilterCounts(p => p.Supervisor.Languages, "Languages");
            await buildFilterCounts(p => p.Supervisor.Modalities, "Modalities");
            await buildFilterCounts(p => p.Supervisor.Religions, "Religions");
            await buildFilterCounts(p => p.Supervisor.SpecialInterests, "Special Interests");
            await buildFilterCounts(p => p.Supervisor.Specialties, "Specialties");
            await buildFilterCounts(p => p.Supervisor.Treatments, "Treatments");

            return result;
        }


        private FilterDefinition<Profile> BuildFilter(ProfileListFilterModel model)
        {
            var filterDefinition = Builders<Profile>.Filter.Ne(p=>p.Supervisor, null);
            return filterDefinition;
        }

        private FilterDefinition<Profile> CreateFilterDefinition(ProfileListFilterModel filter)
        {
            var filterDefinition = Builders<Profile>.Filter.Ne(p=>p.Supervisor, null);
            filterDefinition = filterDefinition & Builders<Profile>.Filter.Eq(p=>p.Account.IsActive, true);
            filterDefinition = filterDefinition & Builders<Profile>.Filter.Eq(p=>p.Supervisor.IsActive, true);

            if(filter != null)
            {
                if(!string.IsNullOrEmpty(filter.ke))
                {
                    //filterDefinition = filterDefinition & Builders<Profile>.Filter.Text(filter.ke);
                    filterDefinition = filterDefinition & Builders<Profile>.Filter.Text(filter.ke, new TextSearchOptions{ CaseSensitive = false });
                }

                if(!string.IsNullOrEmpty(filter.mfz))
                {
                    var location = GetLongLat(filter.mfz);  
                    var point = new GeoJson2DGeographicCoordinates(location.lg, location.lt);
                    var pnt = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(point);
                    //Expression<Func<Profile,Profile>> fieldExpression = p => p.Supervisor.Addresses.Where(_ => _.Type.Equals("Primary"));

                    FieldDefinition<Profile, string> field = "car.manufacture";

                    filterDefinition = filterDefinition & Builders<Profile>.Filter.NearSphere(p => p.Supervisor.Addresses, pnt, filter.mfd);
                    filterDefinition = filterDefinition & Builders<Profile>.Filter.NearSphere()
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
                applyFilterDefinition(p => p.Supervisor.Languages, filter.la);
                applyFilterDefinition(p => p.Supervisor.Modalities, filter.mo);
                applyFilterDefinition(p => p.Supervisor.Religions, filter.re);
                applyFilterDefinition(p => p.Supervisor.SpecialInterests, filter.spIn);
                applyFilterDefinition(p => p.Supervisor.Specialties, filter.sp);
                applyFilterDefinition(p => p.Supervisor.Treatments, filter.tr);
            }

            return filterDefinition;
        }

        private (double lg, double lt) GetLongLat(string zip)
        {
            var result = (lg: 0.0, lt: 0.0);

            var location =
                (from l in _context.Locations.FindAll().AsQueryable()
                where l.zip == zip
                select l).FirstOrDefault();

            if( location != null )
            {
                result = (lg: location.longitude, lt: location.latitude);
            }

            return result;
        }

    }
}
