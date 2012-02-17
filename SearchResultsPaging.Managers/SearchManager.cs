using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchResultsPaging.Types;

namespace SearchResultsPaging.Managers
{
    public static class SearchManager
    {
        /// <summary>
        /// Generate a random list of treasure to simulate a database.
        /// </summary>
        /// <param name="count">Number of items to generate</param>
        /// <returns>List of Treasure</returns>
        public static List<Treasure> GenerateTreasure(int count)
        {
            List<Treasure> treasureList = new List<Treasure>();

            for (int i = 0; i < count; i++)
            {
                treasureList.Add(TreasureManager.CreateRandom());
            }

            return treasureList;
        }

        /// <summary>
        /// Perform search against a list of Treasure (our simulated database).
        /// </summary>
        /// <param name="treasureList">List of Treasure</param>
        /// <param name="page">Page to start results from</param>
        /// <param name="pageSize">Number of items to return</param>
        /// <returns>SearchModel</returns>
        public static SearchModel Search(List<Treasure> treasureList, int page, int pageSize)
        {
            SearchModel searchModel = new SearchModel();

            // Set search points.
            int start = (page * pageSize) - pageSize;
            int end = start + pageSize;
            if (end > treasureList.Count)
            {
                end = treasureList.Count;
            }

            // Set paging information.
            searchModel.CurrentPage = page;
            searchModel.CurrentMin = start + 1;
            searchModel.CurrentMax = end;
            searchModel.PageSize = pageSize;
            searchModel.TotalResults = treasureList.Count;

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
