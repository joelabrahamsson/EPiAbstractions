using EPiServer.Core;

namespace EPiAbstractions.FixtureSupport
{
    public static class PageDataExtensions
    {
        public static PageDataHas<T> With<T>(this T page) where T : PageData
        {
            return new PageDataHas<T>(page);
        }

        public static PageDataHas<T> AndHas<T>(this T page) where T : PageData
        {
            return new PageDataHas<T>(page);
        }

        public static PageDataHas<T> ThatHas<T>(this T page) where T : PageData
        {
            return new PageDataHas<T>(page);
        }

        public static PageDataIs<T> AndIs<T>(this T page) where T : PageData
        {
            return new PageDataIs<T>(page);
        }

        public static PageDataIs<T> ThatIs<T>(this T page) where T : PageData
        {
            return new PageDataIs<T>(page);
        }
    }

    public class PageDataIs<T> where T : PageData
    {
        private T page;

        public PageDataIs(T page)
        {
            this.page = page;
        }

        public T VisibleInMenus()
        {
            page["PageVisibleInMenu"] = true;
            return page;
        }

        public T NotVisibleInMenus()
        {
            page["PageVisibleInMenu"] = false;
            return page;
        }

        public T ChildOf(PageReference parentPageReference)
        {
            page["PageParentLink"] = parentPageReference;
            return page;
        }

        public T ChildOf(PageData parentPage)
        {
            page["PageParentLink"] = parentPage.PageLink;
            return page;
        }
    }

    public class PageDataHas<T> where T : PageData
    {
        private T page;

        public PageDataHas(T page)
        {
            this.page = page;
        }

        public T PageName(string pageName)
        {
            page["PageName"] = pageName;
            return page;
        }

        public T PageLink(PageReference pageReference)
        {
            page.PageLink = pageReference;

            return page;
        }

        public T LinkUrl(string linkUrl)
        {
            page["PageLinkURL"] = linkUrl;

            return page;
        }
    }
}
