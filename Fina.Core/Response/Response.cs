using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace Fina.Core.Response
{
    public  class Response<TData>
    {
        [JsonConstructor]
        public Response() => _Code = Configuration.DefaultSatatusCode;
        
        public Response(TData? _Data,int Code = Configuration.DefaultSatatusCode, string? _Message = null)
        {
            _Code = Code;
            Data = _Data;
            Message = _Message;
        }
        private int _Code = Configuration.DefaultSatatusCode;
        public string? Message { get; set; }
        public TData? Data { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _Code is >= 200 and <= 299;
    }
}
