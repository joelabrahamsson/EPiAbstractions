using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiAbstractions.Core;
using EPiAbstractions.FixtureSupport;
using EPiAbstractions.Opinionated;
using EPiServer.Core;

namespace EPiAbstractions.Fakes
{
    public class FakeEPiServerContext : IEPiServerContext
    {
        private FakeEPiServerContext() {}

        public static FakeEPiServerContext Create()
        {
            return Create<PageData>();
        }

        public static FakeEPiServerContext Create<TStartPage>() where TStartPage : PageData
        {
            var product = new FakeEPiServerContext();

            product.pageRepository = new FakePageRepository();
            
            var rootPage = CreatePage.OfType<TStartPage>();
            product.pageRepository.Publish(rootPage);
            
            var startPage = CreatePage.OfType<TStartPage>()
                .ThatIs().ChildOf(rootPage);
            product.pageRepository.Publish(startPage);

            var wasteBasket = CreatePage.OfType<PageData>()
                .ThatIs().ChildOf(rootPage);
            product.pageRepository.Publish(wasteBasket);

            product.pageReference = new FakePageReferenceFacade(rootPage.PageLink,
                                                        startPage.PageLink,
                                                        wasteBasket.PageLink);

            return product;
        }

        private IPageRepository pageRepository;
        public IPageRepository PageRepository
        {
            get { return pageRepository; }
        }

        private IPageReferenceFacade pageReference;
        public IPageReferenceFacade PageReference
        {
            get { return pageReference; }
        }
    }
}
