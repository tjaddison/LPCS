using System;

namespace LPCS.Server.Providers.DomainModels
{
    public class LogModel
    {
       public string EventType { get; set; }
       public string TriggeredBy { get; set; }
       public string TriggeredFor { get; set; }
       public DateTime TimeTriggered { get; set; }
    }
}