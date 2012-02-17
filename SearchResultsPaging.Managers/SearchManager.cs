using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchResultsPaging.Types;

namespace SearchResultsPaging.Managers
{
    public static class SearchManager
    {
        public static List<Treasure> GenerateTreasure(int count)
        {
            List<Treasure> treasureList = new List<Treasure>();

            for (int i = 0; i < count; i++)
            {
                treasureList.Add(TreasureManager.CreateRandom());
            }

            return treasureList;
        }

        public static SearchModel Search(List<Treasure> treasureList, int page, int pageSize)
        {
            SearchModel searchModel = new SearchModel();

            // Set paging information.
            searchModel.CurrentPage = page;
            searchModel.CurrentMin = (page * pageSize) - pageSize + 1;
            searchModel.CurrentMax = searchModel.CurrentMin + pageSize - 1;
            searchModel.PageSize = pageSize;
            searchModel.TotalResults = treasureList.Count;

            // Set search points.
            int start = (page * pageSize) - pageSize;
            int end = start + pageSize;

            // Run search.
            for (int i = start; i < end; i++)
            {
                searchModel.TreasureList.Add(treasureList[i]);
            }

            // Return results.
            return searchModel;
        }
    }
}
