using System.Collections.Generic;
using EPiServer.Core;

namespace EPiAbstractions.FixtureSupport
{
    public static class EnumerableOfPageDataExtensions
    {
        public static IEnumerable<T> ThatAreAll<T>(this IEnumerable<T> pages) where T : PageData
        {
            return pages;
        }

        public static IEnumerable<T> And<T>(this IEnumerable<T> pages) where T : PageData
        {
            return pages;
        }

        public static IEnumerable<T> ChildrenOf<T>(this IEnumerable<T> pages, PageData parentPage) where T : PageData
        {
            foreach (T page in pages)
            {
                page["PageParentLink"] = parentPage.PageLink;
            }

            return pages;
        }

        public static IEnumerable<T> VisibleInMenus<T>(this IEnumerable<T> pages) where T : PageData
        {
            foreach (T page in pages)
            {
                page["PageVisibleInMenu"] = true;
            }

            return pages;
        }

        public static PageDataCollection AsPageDataCollection<T>(this IEnumerable<T> pages) where T : PageData
        {
            return new PageDataCollection(pages);
        }
    }
}
