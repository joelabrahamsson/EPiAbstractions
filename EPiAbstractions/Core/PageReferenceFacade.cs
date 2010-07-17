using EPiServer.Core;

namespace EPiAbstractions.Core
{
    public class PageReferenceFacade : IPageReferenceFacade
    {
        private static PageReferenceFacade _instance;

        public static PageReferenceFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PageReferenceFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        public PageReference StartPage
        {
            get { return PageReference.StartPage; }
        }

        public PageReference RootPage
        {
            get { return PageReference.RootPage; }
        }

        public PageReference WasteBasket
        {
            get { return PageReference.WasteBasket; }
        }

        public PageReference ParseUrl(string url)
        {
            return PageReference.ParseUrl(url);
        }

        public PageReference Parse(string s)
        {
            return PageReference.Parse(s);
        }

        public bool IsValue(PageReference pageLink)
        {
            return PageReference.IsValue(pageLink);
        }

        public bool IsNullOrEmpty(PageReference pageLink)
        {
            return PageReference.IsNullOrEmpty(pageLink);
        }

        public bool TryParse(string complexReference, out PageReference result)
        {
            return PageReference.TryParse(complexReference, out result);
        }
    }
}
