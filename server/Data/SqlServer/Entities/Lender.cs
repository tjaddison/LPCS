using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.Data.SqlServer.Entities
{
    public class Lender
    {
        public int LenderID { get; set; }

        public string Name { get; set; }

        public int? AddressID { get; set; }

        public string EmployerIDNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public int? SecurityUserID { get; set; }

        public string LastUpdateBy { get; set; }

        public bool IsActiveMCCLender { get; set; }

        public bool MCCIncentiveParticipant { get; set; }

        public DateTime? IncentiveJoinDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public virtual Address Address { get; set; }
    }

}
