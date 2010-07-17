using System.Collections.Generic;
using EPiServer.Core;

namespace EPiAbstractions.Helpers
{
    public static class PageDataCollectionHelper
    {
        public static PageDataCollection ToPageDataCollection(this IEnumerable<PageData> pages)
        {
            return new PageDataCollection(pages);
        }
    }
}
