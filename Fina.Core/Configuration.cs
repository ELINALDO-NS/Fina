using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core
{
  public  static class Configuration
    {
        public const int DefaultSatatusCode = 200;
        public const int DefaultPageNumeber = 1;
        public const int DefaultPageSize = 25;


        public static string BackEndUrl { get; set; } = string.Empty;
        public static string FrontEndUrl { get; set; } = string.Empty;
    }
}
