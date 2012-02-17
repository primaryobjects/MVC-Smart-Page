using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace SearchResultsPaging.Helpers
{
    public static class Html
    {
        /// <summary>
        /// Displays paging for a list of search results.
        /// Created by Kory Becker http://www.primaryobjects.com/articledirectory.aspx
        /// Modified code, based upon http://www.davidpirek.com/blog/aspnet-mvc-paging-digg-style
        /// Example display: Prev 1 2 3 4 5 ... 6 7 8 9 ... 10 11 12 Next
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="intCurrentPage">Current page index</param>
        /// <param name="intPerPage">Number of results per page</param>
        /// <param name="intNumberofItems">Total number of results</param>
        /// <param name="pageNumberPrefix">Text to place in front of page numbers</param>
        /// <param name="linkUrl">Link url to insert into a href="X" (use [PAGE] to replace in the current page)</param>
        /// <param name="onClick">Text to include within the onclick property of the link (use [PAGE] to replace in the current page)</param>
        /// <param name="previousText">Text to show for "Previous" link</param>
        /// <param name="nextText">Text to show for "Next" link</param>
        /// <param name="minPagesForPaging">Minimum number of pages in order for paging to display, otherwise all pages are displayed.</param>
        /// <param name="adjacentPageCount">Number of pages to show around active page index (including left + right + index). For example: 3 => 1, 2, 3 | 2, [3], 4 | 3, [4], 5 | 48, 49, [50]</param>
        /// <param name="nonAdjacentPageCount">Number of pages to show for non-active page indexes (such as right-most numbers, if a left-most number is active)</param>
        /// <param name="pageCalculation">Optional anonymous method, allowing you alter the returned page index for each link by specifying a function that receives the page index and returns the "modified" page index. For example, converting 2 => 21 or converting 272 => 5421. Set to NULL to use the original page index.</param>
        /// <returns>string html</returns>
        public static string SmartPage(this HtmlHelper helper, int intCurrentPage, int intPerPage, int intNumberofItems, string pageNumberPrefix, string linkUrl, string onClick, string previousText, string nextText, int minPagesForPaging = 3, int adjacentPageCount = 3, int nonAdjacentPageCount = 1, Func<int, int> pageCalculation = null)
        {
            string strPreviousText = previousText;
            string strNextText = nextText;

            StringBuilder sb = new StringBuilder();

            if (intCurrentPage < 1)
            {
                intCurrentPage = 1;
            }

            int number_of_pages = (int)Math.Ceiling((double)intNumberofItems / (double)intPerPage);

            int i = 0;

            //hide paging if only one page
            if (number_of_pages > 1)
            {
                //previous record
                if (!(intCurrentPage == 1))
                {
                    int page = intCurrentPage - 1;
                    if (pageCalculation != null)
                    {
                        page = pageCalculation((intCurrentPage - 1));
                    }

                    sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + strPreviousText + "</a></span>");
                }
                else
                {
                    sb.Append("<span style=\"color:#c0c0c0;\">" + previousText + "</span>");
                }

                if (number_of_pages < minPagesForPaging)
                {
                    // Display all pages, no paging.
                    for (i = 0; i < number_of_pages; i++)
                    {
                        if (!(i == intCurrentPage - 1))
                        {
                            int page = i + 1;
                            if (pageCalculation != null)
                            {
                                page = pageCalculation((i + 1));
                            }

                            sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + (i + 1) + pageNumberPrefix + "</a></span>");
                        }
                        else
                        {
                            sb.Append("<span>" + (i + 1) + pageNumberPrefix + "</span>");
                        }

                    }
                }
                else
                {
                    if (intCurrentPage < adjacentPageCount)
                    {
                        // Scenario 1: Left-most numbers are active.

                        // Left-most page numbers.
                        for (i = 0; i < adjacentPageCount; i++)
                        {
                            if (!(i == intCurrentPage - 1))
                            {
                                int page = i + 1;
                                if (pageCalculation != null)
                                {
                                    page = pageCalculation((i + 1));
                                }

                                sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + (i + 1) + pageNumberPrefix + "</a></span>");
                            }
                            else
                            {
                                sb.Append("<span>" + (i + 1) + pageNumberPrefix + "</span>");
                            }
                        }

                        sb.Append("<span class='pg_dots'>...</span>");

                        // Right-most page numbers.
                        for (i = number_of_pages - nonAdjacentPageCount; i < number_of_pages; i++)
                        {
                            if (!(i == intCurrentPage - 1))
                            {
                                int page = i + 1;
                                if (pageCalculation != null)
                                {
                                    page = pageCalculation((i + 1));
                                }

                                sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + (i + 1) + pageNumberPrefix + "</a></span>");
                            }
                            else
                            {
                                sb.Append("<span>" + (i + 1) + pageNumberPrefix + "</span>");
                            }
                        }
                    }
                    else if (intCurrentPage > number_of_pages - (adjacentPageCount - 1))
                    {
                        // Scenario 2: Right-most numbers are active.

                        // Left-most page numbers.
                        for (i = 0; i < nonAdjacentPageCount; i++)
                        {
                            if (!(i == intCurrentPage - 1))
                            {
                                int page = i + 1;
                                if (pageCalculation != null)
                                {
                                    page = pageCalculation((i + 1));
                                }

                                sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + (i + 1) + pageNumberPrefix + "</a></span>");
                            }
                            else
                            {
                                sb.Append("<span>" + (i + 1) + pageNumberPrefix + "</span>");
                            }
                        }

                        sb.Append("<span class='pg_dots'>...</span>");

                        // Right-most page numbers.
                        for (i = number_of_pages - adjacentPageCount; i < number_of_pages; i++)
                        {
                            if (!(i == intCurrentPage - 1))
                            {
                                int page = i + 1;
                                if (pageCalculation != null)
                                {
                                    page = pageCalculation((i + 1));
                                }

                                sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + (i + 1) + pageNumberPrefix + "</a></span>");
                            }
                            else
                            {
                                sb.Append("<span>" + (i + 1) + pageNumberPrefix + "</span>");
                            }
                        }
                    }
                    else
                    {
                        // Scenario 3: Middle numbers are active.

                        // Draw left-most numbers.
                        for (i = 0; i < nonAdjacentPageCount; i++)
                        {
                            if (!(i == intCurrentPage - 1))
                            {
                                int page = i + 1;
                                if (pageCalculation != null)
                                {
                                    page = pageCalculation((i + 1));
                                }

                                sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + (i + 1) + pageNumberPrefix + "</a></span>");
                            }
                            else
                            {
                                sb.Append("<span>" + (i + 1) + pageNumberPrefix + "</span>");
                            }
                        }

                        sb.Append("<span class='pg_dots'>...</span>");

                        // Draw middle numbers.
                        for (i = intCurrentPage - (adjacentPageCount / 2); i <= intCurrentPage + (adjacentPageCount / 2); i++)
                        {
                            if (i != intCurrentPage)
                            {
                                int page = i;
                                if (pageCalculation != null)
                                {
                                    page = pageCalculation(i);
                                }

                                sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + i + pageNumberPrefix + "</a></span>");
                            }
                            else
                            {
                                sb.Append("<span>" + i + pageNumberPrefix + "</span>");
                            }
                        }

                        sb.Append("<span>...</span>");

                        // Draw right-most numbers.
                        for (i = number_of_pages - nonAdjacentPageCount; i < number_of_pages; i++)
                        {
                            if (!(i == intCurrentPage - 1))
                            {
                                int page = i + 1;
                                if (pageCalculation != null)
                                {
                                    page = pageCalculation((i + 1));
                                }

                                sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + (i + 1) + pageNumberPrefix + "</a></span>");
                            }
                            else
                            {
                                sb.Append("<span>" + (i + 1) + pageNumberPrefix + "</span>");
                            }

                        }
                    }
                }

                //next record
                if (intCurrentPage != number_of_pages)
                {
                    int page = intCurrentPage + 1;
                    if (pageCalculation != null)
                    {
                        page = pageCalculation((intCurrentPage + 1));
                    }

                    sb.Append("<span><a href='" + linkUrl.Replace("[PAGE]", page.ToString()) + "' onclick='" + onClick.Replace("[PAGE]", page.ToString()) + "'>" + strNextText + "</a></span>");
                }
                else
                {
                    sb.Append("<span style=\"color:#c0c0c0;\">" + nextText + "</span>");
                }

                sb.Append("<!-- end of 'paging' -->");

                //builds string
                return sb.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}