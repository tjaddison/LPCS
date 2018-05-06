using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.Data.SqlServer.Entities
{
    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
        public string StateAbbrev { get; set; }
        public bool IsActive { get; set; }
        public virtual Address Address { get; set; }

    }
}
