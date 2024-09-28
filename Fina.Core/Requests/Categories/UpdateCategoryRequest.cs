using Fina.Core.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Categories
{
    public class UpdateCategoryRequest : Request
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Título Invalido")]
        [MaxLength(80, ErrorMessage = "O titulo de conter no maxio 80 caracteres")]
        public string Title { get; set; } = string.Empty;
        [MaxLength(ErrorMessage = "Descrição invalida")]
        public string Description { get; set; } = string.Empty;
    }
}
