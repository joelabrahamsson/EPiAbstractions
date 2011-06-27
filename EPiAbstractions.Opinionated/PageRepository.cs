using System;
using System.Collections.Generic;
using System.Linq;
using EPiAbstractions.Filters;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using PageTypeBuilder;

namespace EPiAbstractions.Opinionated
{
    public class PageRepository : IPageRepository
    {
        private IDataFactoryFacade dataFactory;
        private IFilterForVisitorFacade filterForVisitor;

        public PageRepository(IDataFactoryFacade dataFactoryFacade, IFilterForVisitorFacade filterForVisitorFacade)
        {
            dataFactory = dataFactoryFacade;
            filterForVisitor = filterForVisitorFacade;
        }

        public PageRepository()
            : this (DataFactoryFacade.Instance, FilterForVisitorFacade.Instance) {}

        public virtual PageData GetPage(PageReference pageLink)
        {
            return GetPage<PageData>(pageLink);
        }

        public virtual T GetPage<T>(PageReference pageLink) where T : PageData
        {
            return dataFactory.GetPage(pageLink) as T;
 
        }

        public virtual PageData GetPage(PageReference pageLink, ILanguageSelector selector)
        {
            return GetPage<PageData>(pageLink, selector);
        }

        public virtual T GetPage<T>(PageReference pageLink, ILanguageSelector selector) where T : PageData
        {
            return dataFactory.GetPage(pageLink, selector) as T;
        }

        public virtual IEnumerable<T> GetChildren<T>(PageReference pageLink) where T : PageData
        {
            return dataFactory.GetChildren(pageLink).OfType<T>();
        }

        public virtual IEnumerable<T> GetChildren<T>(PageReference pageLink, ILanguageSelector selector) where T : PageData
        {
            return dataFactory.GetChildren(pageLink, selector).OfType<T>();
        }

        public IEnumerable<T> GetChildrenAccessibleToCurrentUser<T>(PageReference pageLink) where T : PageData
        {
            var unfilteredChildren = dataFactory.GetChildren(pageLink);
            return filterForVisitor.Filter(unfilteredChildren).OfType<T>();
        }

        public IEnumerable<T> GetChildrenAccessibleToCurrentUser<T>(PageReference pageLink, ILanguageSelector selector) where T : PageData
        {
            var unfilteredChildren = dataFactory.GetChildren(pageLink, selector);
            return filterForVisitor.Filter(unfilteredChildren).OfType<T>();
        }

        public virtual T GetDefaultPageData<T>(PageReference parentPageLink) where T : PageData
        {
            int? pageTypeId = PageTypeResolver.Instance.GetPageTypeID(typeof (T));
            if (!pageTypeId.HasValue)
                throw new PageRepositoryException(string.Format("Unable to get page type Id for type {0}",
                                                                typeof (T).FullName));

            return (T) dataFactory.GetDefaultPageData(parentPageLink, pageTypeId.Value);
        }

        public virtual T GetDefaultPageData<T>(PageReference parentPageLink, ILanguageSelector selector) where T : PageData
        {
            int? pageTypeId = PageTypeResolver.Instance.GetPageTypeID(typeof(T));
            if (!pageTypeId.HasValue)
                throw new PageRepositoryException(string.Format("Unable to get page type Id for type {0}",
                                                                typeof(T).FullName));

            return (T)dataFactory.GetDefaultPageData(parentPageLink, pageTypeId.Value, selector);
        }

        /// <summary>
        /// Saves the page without checking that the user has the necessary access rights.
        /// </summary>
        public PageReference Save(PageData page, SaveAction action)
        {
            return dataFactory.Save(page, action, AccessLevel.NoAccess);
        }

        /// <summary>
        /// Saves and publishes the page without checking that the user has the necessary access rights.
        /// </summary>
        public PageReference Publish(PageData page)
        {
            return dataFactory.Save(page, SaveAction.Publish, AccessLevel.NoAccess);
        }

        /// <summary>
        /// Deletes the specified page even if it is being linked by other pages. Does not check that the
        /// user has the necessary access rights.
        /// </summary>
        public void Delete(PageData pageData)
        {
            dataFactory.Delete(pageData.PageLink, true, AccessLevel.NoAccess);
        }

        /// <summary>
        /// Gets all of the page's ancestors such as it's parent, grandparent etc.
        /// </summary>
        public IEnumerable<PageReference> GetAncestors(PageData pageData)
        {
            return dataFactory.GetParents(pageData.PageLink);
        }

        /// <summary>
        /// Gets descendents (children, grandchildren etc) of a page filtered by access rights and publication status.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageLink"></param>
        /// <returns></returns>
        public IEnumerable<T> GetDescendentsAccessibleToCurrentUser<T>(PageReference pageLink) where T : PageData
        {
            return filterForVisitor.Filter(dataFactory.GetDescendents(pageLink)
                .Select(reference => GetPage<PageData>(reference)))
                .Cast<T>();
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

        ///<summary>
        /// Moves a page under another parent
        ///</summary>
        ///<param name="page">The page to be moved</param>
        ///<param name="newParent">The new parent</param>
        public void Move(PageReference page, PageReference newParent)
        {
            dataFactory.Move(page, newParent);
        }
    }
}
