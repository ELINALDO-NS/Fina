using Fina.Core.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Response.Categories
{
    public class DeleteCategoryResquest:Request
    {
        [Required(ErrorMessage ="É necessario informar um Id para exclusão")]
        public long Id { get; set; }
    }
}
