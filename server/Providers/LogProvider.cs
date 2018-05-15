using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LPCS.Server.Core.Data;
using LPCS.Server.Data.Mongo;
using LPCS.Server.Data.Mongo.Entities;
using LPCS.Server.Providers.DomainModels;


namespace LPCS.Server.Providers
{
    public class LogProvider : ILogProvider
    {
        private readonly LpcsMongoContext _context;
        private readonly AutoMapper.IMapper _mapper;

        public LogProvider(LpcsMongoContext context, AutoMapper.IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<LogModel>> GetLogs(int page, int size)
        {
            PagedResult<LogModel> result = null;

            var fd = _context.Logs.Filter.Eq(p=>p.EventType, "ProfileSearch");
            //fd = fd | _context.Logs.Filter.Eq(p=>p.EventType, "AccountDeactivated");

            var cnt = await _context.Logs.CountAsync(fd);

            //var cnt = await _context.Logs.CountAsync();
            
            var logs = _context.Logs.Find(
                filterDefinition: fd,
                pageIndex: page, 
                size: size, 
                isDescending: true, 
                order: l=>l.TimeTriggered);
            var items = _mapper.Map<IEnumerable<LogModel>>(logs);
            result = new PagedResult<LogModel>(items, cnt);
            return result;
        }

        public async Task CreateLog(LogModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = _mapper.Map<Log>(model);
            await _context.Logs.InsertAsync(entity);
        }
    }
}