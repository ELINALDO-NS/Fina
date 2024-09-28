using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Model
{
    public class Category
    {

        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;    
        public string? Description { get; set; } 
        public string UserId { get; set; } = string.Empty;

    }
}
