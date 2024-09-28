using Fina.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Response.Transactions
{
    public class GetTransactionByIdRequest:Request
    {
        public long Id { get; set; }
    }
}
