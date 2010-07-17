using System.Collections.Generic;
using EPiServer.Core;

namespace EPiAbstractions.Filters
{
    public interface IFilterForVisitorFacade
    {
        PageDataCollection Filter(PageDataCollection pages);

        IEnumerable<PageData> Filter(IEnumerable<PageData> pages);
    }
}
