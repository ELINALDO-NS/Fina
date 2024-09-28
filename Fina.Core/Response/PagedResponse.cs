using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fina.Core.Response
{
    public class PagedResponse<TData>:Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(TData data,int totaCount,int currentPage = 1,int pageSize = Configuration.DefaultPageSize):base(data)
        {
            Data = data;
            TotalCount = totaCount;
            CurrentPage = currentPage;
            PageSize = pageSize;

        }
        public int CurrentPage { get; set; }
        public int TotalPage => (int)Math.Ceiling(TotalPage/ (double)PageSize);
        public int PageSize { get; } = Configuration.DefaultPageSize;
        public int TotalCount { get; }
    }
}
