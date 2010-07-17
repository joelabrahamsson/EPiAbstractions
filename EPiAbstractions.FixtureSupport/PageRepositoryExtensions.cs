using System.Collections.Generic;
using EPiAbstractions.Opinionated;
using EPiServer.Core;

namespace EPiAbstractions.FixtureSupport
{
    public static class PageRepositoryExtensions
    {
        public static void Publish(this IPageRepository pageRepository, IEnumerable<PageData> pages)
        {
            foreach (var page in pages)
                pageRepository.Publish(page);
        }
    }
}
