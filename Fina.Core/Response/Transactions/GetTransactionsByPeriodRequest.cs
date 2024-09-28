using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Response.Transactions
{
    public class GetTransactionsByPeriodRequest:PagedRequest
    {
        public DateTime? StatDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
