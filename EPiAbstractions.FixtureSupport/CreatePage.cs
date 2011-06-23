using Castle.DynamicProxy;
using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace EPiAbstractions.FixtureSupport
{
    public class CreatePage
    {
        private static int nextPageId = 1;

        public static T OfType<T>(params object[] constructorArguments) where T : PageData
        {
            T product = CreateInstanceOfClass<T>(constructorArguments);

            product.Property["PageLink"] = new PropertyPageReference();
            product.Property["PageName"] = new PropertyString();
            product.Property["PageTypeID"] = new PropertyNumber();
            product.Property["PageParentLink"] = new PropertyPageReference();
            product.Property["PageDeleted"] = new PropertyBoolean(false);
            product.Property["PageMasterLanguageBranch"] = new PropertyLanguage();
            product.Property["PageVisibleInMenu"] = new PropertyBoolean(true);
            product.Property["PageChildOrderRule"] = new PropertyNumber(1);
            product.Property["PagePeerOrder"] = new PropertyNumber(0);
            product.Property["PageTypeName"] = new PropertyString();
            product.Property["PagePendingPublish"] = new PropertyBoolean(true);
            product.Property["PageWorkStatus"] = new PropertyNumber(2);
            product.Property["PageLanguageBranch"] = new PropertyLanguage();
            product.Property["PageStartPublish"] = new PropertyDate();
            product.Property["PageStopPublish"] = new PropertyDate();
            product.Property["PageCreated"] = new PropertyDate();
            product.Property["PageShortcutType"] = new PropertyNumber(0);
            product.Property["PageLinkURL"] = new PropertyString();

            nextPageId++;

            return product;
        }

        private static T CreateInstanceOfClass<T>(params object[] constructorArguments)
        {
            var proxyGenerator = new ProxyGenerator();
            return (T) proxyGenerator.CreateClassProxy(typeof (T), constructorArguments, new IInterceptor[] {});

        }
    }
}
