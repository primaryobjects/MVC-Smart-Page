using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchResultsPaging.Types
{
    public class SearchModel
    {
        public List<Treasure> TreasureList { get; set; }
        public int TotalResults { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int CurrentMin { get; set; }
        public int CurrentMax { get; set; }
        public int AdjacentPageCount { get; set; }
        public int NonAdjacentPageCount { get; set; }

        public SearchModel()
        {
            TreasureList = new List<Treasure>();
        }
    }
}
