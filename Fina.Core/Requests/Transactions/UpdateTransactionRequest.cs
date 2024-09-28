using Fina.Core.Enums;
using Fina.Core.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Transactions
{
    public class UpdateTransactionRequest : Request
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Título Invalido")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Tipo invalido")]
        public ETransectionType Type { get; set; } = ETransectionType.Deposit;
        [Required(ErrorMessage = "Valor invalido")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Categoria invalida")]
        public long CategoryId { get; set; }
        [Required(ErrorMessage = "Data Invalida")]
        public DateTime? PaidOrReceiveAt { get; set; }
    }
}
