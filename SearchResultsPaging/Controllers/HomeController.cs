using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchResultsPaging.Types;
using SearchResultsPaging.Managers;

namespace SearchResultsPaging.Controllers
{
    public class HomeController : Controller
    {
        private static List<Treasure> _treasureList = SearchManager.GenerateTreasure(120);

        public ActionResult Index(int page, int pageSize)
        {
            // Get search results.
            SearchModel searchModel = SearchManager.Search(_treasureList, page, pageSize);

            // Return results to view.
            if (Request.IsAjaxRequest())
            {
                return PartialView("/Views/Controls/SearchResults.cshtml", searchModel);
            }
            else
            {
                return View(searchModel);
            }
        }
    }
}
