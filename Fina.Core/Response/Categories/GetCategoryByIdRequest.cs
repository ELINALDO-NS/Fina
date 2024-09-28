using Fina.Core.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Response.Categories
{
    public class GetCategoryByIdRequest:Request
    {
        [Required(ErrorMessage ="É necessario informar o Id da categoria")]
        public long Id { get; set; }
    }
}
