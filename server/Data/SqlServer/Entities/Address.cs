using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.Data.SqlServer.Entities
{
    public class Address
    {
        public int AddressID { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public int? StateID { get; set; }

        public string Zip { get; set; }

        public int? CountyID { get; set; }

        public bool IsActive { get; set; }

        public string LastUpdateBy { get; set; }

        public string AlternateCity { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public virtual Lender Lender { get; set; }
        public virtual State State { get; set; }

    }

}
