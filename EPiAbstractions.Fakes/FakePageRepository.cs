using System;
using System.Collections.Generic;
using System.Linq;
using EPiAbstractions.FixtureSupport;
using EPiAbstractions.Helpers;
using EPiAbstractions.Opinionated;
using EPiServer.Core;
using EPiServer.DataAccess;

namespace EPiAbstractions.Fakes
{
    public class FakePageRepository : IPageRepository
    {
        private int nextId = 1;
        private Dictionary<PageReference, PageData> pages = new Dictionary<PageReference, PageData>();

        private bool IsChildOf(PageData page, PageReference pageLink)
        {
            return page.ParentLink.CompareToIgnoreWorkID(pageLink);
        }

        public virtual T GetPage<T>(PageReference pageLink) where T : PageData
        {
            if (!PageReference.IsValue(pageLink))
            {
                throw new ArgumentNullException("pageLink", "Parameter has no page set");
            }

            if(!pages.ContainsKey(pageLink))
                throw new PageNotFoundException(pageLink);

            return pages[pageLink] as T;
        }

        public virtual PageReference Save(PageData page, SaveAction action)
        {
            if (PageReference.IsNullOrEmpty(page.PageLink))
            {
                page.Property["PageLink"] = new PropertyPageReference(new PageReference(nextId));
                nextId++;
                pages.Add(page.PageLink, page);
            }

            return page.PageLink;
        }


        public T GetPage<T>(PageReference pageLink, ILanguageSelector selector) where T : PageData
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildren<T>(PageReference pageLink) where T : PageData
        {
            return pages.Values
                .Where(page => IsChildOf(page, pageLink))
                .ToPageDataCollection().OfType<T>();
        }

        public IEnumerable<T> GetChildren<T>(PageReference pageLink, ILanguageSelector selector) where T : PageData
        {
            throw new NotImplementedException();
        }

        public T GetDefaultPageData<T>(PageReference parentPageLink) where T : PageData
        {
            return CreatePage.OfType<T>().ThatIs().ChildOf(parentPageLink);
        }

        public T GetDefaultPageData<T>(PageReference parentPageLink, ILanguageSelector selector) where T : PageData
        {
            throw new NotImplementedException();
        }

        public PageReference Publish(PageData page)
        {
            return Save(page, SaveAction.Publish);
        }

        public IEnumerable<T> GetChildrenAccessibleToCurrentUser<T>(PageReference pageLink) where T : PageData
        {
            return GetChildren<T>(pageLink);
        }

        public IEnumerable<T> GetChildrenAccessibleToCurrentUser<T>(PageReference pageLink, ILanguageSelector selector) where T : PageData
        {
            throw new NotImplementedException();
        }

        public void Delete(PageData pageData)
        {
            var children = GetChildren<PageData>(pageData.PageLink);
            foreach (var child in children)
            {
                Delete(child);
            }

            pages.Remove(pageData.PageLink);
        }

        public IEnumerable<PageReference> GetAncestors(PageData pageData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetDescendentsAccessibleToCurrentUser<T>(PageReference pageLink) where T : PageData
        {
            List<T> descendents = new List<T>();
            IEnumerable<T> children = GetChildrenAccessibleToCurrentUser<T>(pageLink);
            descendents.AddRange(children);
            foreach (var child in children)
            {
                descendents.AddRange(GetDescendentsAccessibleToCurrentUser<T>(child.PageLink));
            }

            return descendents;
        }

        public PageData GetPage(PageReference pageLink)
        {
            return GetPage<PageData>(pageLink);
        }

        public PageData GetPage(PageReference pageLink, ILanguageSelector selector)
        {
            throw new NotImplementedException();
        }

        public bool TryGetPage<T>(PageReference pageLink, out T page) where T : PageData
        {
            page = null;

            try
            {
                page = GetPage<T>(pageLink);
            }
            catch (PageNotFoundException)
            {
                return false;
            }

            return page != null;
        }
    }
}
