using Fina.Core.Requests.Transactions;
using Fina.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Fina.Core.Handlers
{
    public interface ITransactionHandler
    {
        Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest createTransaction); 
        Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest updateTransaction); 
        Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest deleteTransaction); 
        Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest getTransactionById); 
        Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest getTransactionsByPeriod); 
    }
}
