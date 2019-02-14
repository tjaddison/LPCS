using System;
using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Entities
{
    public class Message : Entity
    {
        public string FromAccountID { get; set; }
        public string ToAccountID { get; set; }
        public string Value { get; set; }
        public DateTime? TimeReceived { get; set; }
        public DateTime TimeSent { get; set; }
    }
}