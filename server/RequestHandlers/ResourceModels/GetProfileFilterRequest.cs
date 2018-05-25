using LPCS.Server.Core.Web;
using LPCS.Server.Providers.DomainModels;
using LPCS.Server.RequestHandlers.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.RequestHandlers.ResourceModels
{
    public class GetProfileFilterRequest : BaseGetRequest<GetProfileFilterRequest, GetProfileFilterResponse, GetProfileFilterRequestValidator>
    {
        public ProfileListFilterModel F { get; set; }
    }
}