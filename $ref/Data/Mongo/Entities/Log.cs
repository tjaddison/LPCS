using System;
using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Entities
{
    public class Log : Entity
    {
       public string EventType { get; set; }
       public string TriggeredBy { get; set; }
       public string TriggeredFor { get; set; }
       public DateTime TimeTriggered { get; set; }
    }

    public enum EventType {
        AccountCreated,
        AccountActivated,
        AccountDeactivated,        
        ProfileUpdated,
        ProfileActivated,
        ProfileDeactivated,
        ProfileSearch,
        ProfileVisit,
        SignIn,
        WebsiteVisit,
        FacebookVisit,
        LinkedInVisit,
        TwitterVisit,
        InstagramVisit,
        PurchasedSubscription,
        CancelledSubscription
    }

 


}