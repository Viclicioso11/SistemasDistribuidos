using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Pager
{
    public class GenericPager<T> where T : class
    {
        public int ActualPage { get; set; }

        public int RecordsByPage { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages { get; set; } 

        public  List<T> Results { get; set; }
    }
}
