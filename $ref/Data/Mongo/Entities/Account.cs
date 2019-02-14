namespace LPCS.Server.Data.Mongo.Entities
{
    public class Account
    {
        public bool IsActive { get; set; }
        public string StripeCustomerID { get; set; }
    }
}