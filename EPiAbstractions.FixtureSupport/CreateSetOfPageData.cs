using System.Collections.Generic;
using EPiServer.Core;

namespace EPiAbstractions.FixtureSupport
{
    public static class CreateSetOfPageData
    {
        public static CreateSetOfPageDataSetup Containing(int numberOfPages)
        {
            return new CreateSetOfPageDataSetup(numberOfPages);
        }

        public class CreateSetOfPageDataSetup
        {
            private int numberOfPages;

            public CreateSetOfPageDataSetup(int numberOfPages)
            {
                this.numberOfPages = numberOfPages;
            }

            public IEnumerable<PageData> Pages()
            {
                return PagesOfType<PageData>();
            }

            public IEnumerable<T> PagesOfType<T>(params object[] ctorParameters) where T : PageData
            {
                var pages = new List<T>();
                for (int i = 0; i < numberOfPages; i++)
                {
                    T page = CreatePage.OfType<T>(ctorParameters);
                    pages.Add(page);
                }

                return pages;
            }
        }
    }
}
