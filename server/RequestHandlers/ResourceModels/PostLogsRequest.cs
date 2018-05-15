using System;
using LPCS.Server.Core.Web;
using LPCS.Server.Providers.DomainModels;
using LPCS.Server.RequestHandlers.Validators;

namespace LPCS.Server.RequestHandlers.ResourceModels
{
    public class PostLogsRequest : BasePostRequest<LogModel, PostLogsRequest, PostLogsResponse, PostLogsRequestValidator>
    {

    }
}
