using Fina.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Model
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreateAT { get; set; } = DateTime.UtcNow;
        public DateTime? PaidOrReceiveAt { get; set; }
        public ETransectionType Type { get; set; } = ETransectionType.WithDraw;
        public decimal Amount { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; } = null;
        public string UserId { get; set; } = string.Empty;
    }
}
