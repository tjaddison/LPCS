using LPCS.Server.Core.Web;
using LPCS.Server.RequestHandlers.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.RequestHandlers.ResourceModels
{
    public class GetSingleProfileRequest : BaseGetRequest<GetSingleProfileRequest, GetSingleProfileResponse, GetSingleProfileRequestValidator>
    {
        public string ID { get; set; }
    }
}
