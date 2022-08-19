using System.Collections.Generic;
using Talabat.DTO;

namespace Talabat.Helper
{
    public class Pagination<T>
    {

        
        public Pagination(int pageIndex, int pageSize,int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Data = data;


        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }


        public int count { get; set; }

        public IReadOnlyList<T> Data { get; set; }

    }
}
