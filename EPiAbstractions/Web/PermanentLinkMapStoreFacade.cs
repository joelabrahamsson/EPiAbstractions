using EPiServer;
using EPiServer.Web;

namespace EPiAbstractions.Web
{
    public class PermanentLinkMapStoreFacade : IPermanentLinkMapStoreFacade 
    {
        public virtual bool ToMapped(UrlBuilder url)
        {
            return PermanentLinkMapStore.ToMapped(url);
        }

        public virtual bool ToPermanent(UrlBuilder url)
        {
            return PermanentLinkMapStore.ToPermanent(url);
        }

        public virtual bool TryToMapped(string url, out string mappedUrl)
        {
            return PermanentLinkMapStore.TryToMapped(url, out mappedUrl);
        }

        public virtual bool TryToPermanent(string url, out string permanentUrl)
        {
            return PermanentLinkMapStore.TryToPermanent(url, out permanentUrl);
        }
    }
}
