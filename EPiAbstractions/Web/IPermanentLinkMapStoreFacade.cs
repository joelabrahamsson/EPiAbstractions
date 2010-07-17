using EPiServer;

namespace EPiAbstractions.Web
{
    public interface IPermanentLinkMapStoreFacade
    {
        bool ToMapped(UrlBuilder url);
        bool ToPermanent(UrlBuilder url);
        bool TryToMapped(string url, out string mappedUrl);
        bool TryToPermanent(string url, out string permanentUrl);
    }
}
