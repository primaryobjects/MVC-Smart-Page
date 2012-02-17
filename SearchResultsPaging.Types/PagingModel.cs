using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchResultsPaging.Types
{
    public class PagingModel
    {
        public int TotalResults { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int CurrentResultsMax { get; set; }
        public int CurrentResultsMin { get; set; }

        public PagingModel()
        {
        }

        public PagingModel(int totalResults, int currentPage, int pageSize, int currentResultsMax, int currentResultsMin)
        {
            TotalResults = totalResults;
            CurrentPage = currentPage;
            PageSize = pageSize;
            CurrentResultsMax = currentResultsMax;
            CurrentResultsMin = currentResultsMin;
        }
    }
}
