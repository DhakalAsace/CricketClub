﻿using System.Collections.Generic;
using System.Linq;

namespace CMS.Web.LEPagination
{
    public interface PreviousPageService
    {
        PreviousPage BuildPreviousPage(List<Page> pages, int collectionSize, int selectedPageNumber, int itemsPerPage);
    }

    public class PreviousPageServiceImpl : PreviousPageService
    {
        /// <summary>
        /// Build previous page object
        /// </summary>
        public PreviousPage BuildPreviousPage(List<Page> pages, int collectionSize, int selectedPageNumber, int itemsPerPage)
        {
            var display = DisplayPreviousPage(collectionSize, selectedPageNumber, itemsPerPage);
            return new PreviousPage
            {
                Display = display,
                PageNumber = display ? pages.First(x => x.IsCurrent).PageNumber - 1 : 1
            };
        }

        /// <summary>
        /// Determine if we need a Previous Page
        /// </summary>
        private static bool DisplayPreviousPage(int collectionSize, int selectedPageNumber, int itemsPerPage)
        {
            return selectedPageNumber > 1 && collectionSize >= itemsPerPage;
        }
    }
}