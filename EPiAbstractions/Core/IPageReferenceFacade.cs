using EPiServer.Core;

namespace EPiAbstractions.Core
{
    public interface IPageReferenceFacade
    {
        PageReference StartPage { get; }

        PageReference RootPage { get; }

        PageReference WasteBasket { get; }

        PageReference ParseUrl(string url);

        PageReference Parse(string s);

        bool IsValue(PageReference pageLink);

        bool IsNullOrEmpty(PageReference pageLink);

        bool TryParse(string complexReference, out PageReference result);
    }
}
