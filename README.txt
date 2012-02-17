MVC Smart Page - MVC .NET Search Result Pager with Customizable Paging

This is an example MVC C# ASP .NET web application, demonstrating
how to page search results using a smart, slick, configurable pager.

Example:

1 | 2 | 3 ... 10

1 ... 3 | 4 | 5 ... 10

1 ... 8 | 9 | 10

DESCRIPTION:

MVC Smart Page is an MVC Helper method which returns HTML to display paged search result indexes, similar
to the traditional "Digg-style" search results pager. To use, simply pass the Smart Page method a series of parameters to customize the style of your paging, as described below. Smart Page will automatically calculate paging and display the resulting HTML.

You can configure MVC Smart Page to set the minimum pages before paging displays, number of adjacent pages, number of non-adjacent pages, and even alter the value for the page number (in case your search method takes a search result index, rather than a page index).

It's quite easy to use. Give the demo a try and see for yourself.

Method:

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

public static string SmartPage(this HtmlHelper helper,
                               int intCurrentPage,
                               int intPerPage,
                               int intNumberofItems,
                               string pageNumberPrefix,
                               string linkUrl,
                               string onClick,
			       string previousText,
			       string nextText,
			       int minPagesForPaging = 3,
			       int adjacentPageCount = 3,
			       int nonAdjacentPageCount = 1,
			       Func<int, int> pageCalculation = null)

---

Copyright © 2012 Kory Becker (http://www.primaryobjects.com)

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
