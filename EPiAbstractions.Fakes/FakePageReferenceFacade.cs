using System;
using EPiAbstractions.Core;
using EPiServer.Core;

namespace EPiAbstractions.Fakes
{
    public class FakePageReferenceFacade : IPageReferenceFacade
    {
        public FakePageReferenceFacade(PageReference rootPage,
            PageReference startPage,
            PageReference wasteBasket)
        {
            this.startPage = startPage;
            this.rootPage = rootPage;
            this.wasteBasket = wasteBasket;
        }

        private PageReference startPage;
        public PageReference StartPage
        {
            get { return startPage; }
        }

        private PageReference rootPage;
        public PageReference RootPage
        {
            get { return rootPage; }
        }

        private PageReference wasteBasket;
        public PageReference WasteBasket
        {
            get { return wasteBasket; }
        }

        public PageReference ParseUrl(string url)
        {
            throw new NotImplementedException();
        }

        public virtual PageReference Parse(string s)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsValue(PageReference pageLink)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsNullOrEmpty(PageReference pageLink)
        {
            throw new NotImplementedException();
        }

        public virtual bool TryParse(string complexReference, out PageReference result)
        {
            throw new NotImplementedException();
        }
    }
}
