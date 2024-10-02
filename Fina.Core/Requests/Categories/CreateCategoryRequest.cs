﻿using Fina.Core.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Categories
{
    public class CreateCategoryRequest : Request
    {
        
        [Required(ErrorMessage = "Título invalido")]
        [MaxLength(80, ErrorMessage = "O titulo de conter no maxio 80 caracteres")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Descrição Invalida")]
        public string Description { get; set; } = string.Empty;
    }
}
