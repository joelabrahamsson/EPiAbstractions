using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.DataAccess;

namespace EPiAbstractions.Opinionated
{
    public interface IPageRepository
    {
        PageData GetPage(PageReference pageLink);

        T GetPage<T>(PageReference pageLink) where T : PageData;

        PageData GetPage(PageReference pageLink, ILanguageSelector selector);

        T GetPage<T>(PageReference pageLink, ILanguageSelector selector) where T : PageData;

        IEnumerable<T> GetChildren<T>(PageReference pageLink) where T : PageData;

        IEnumerable<T> GetChildren<T>(PageReference pageLink, ILanguageSelector selector) where T : PageData;

        IEnumerable<T> GetChildrenAccessibleToCurrentUser<T>(PageReference pageLink) where T : PageData;

        IEnumerable<T> GetChildrenAccessibleToCurrentUser<T>(PageReference pageLink, ILanguageSelector selector) where T : PageData;

        T GetDefaultPageData<T>(PageReference parentPageLink) where T : PageData;

        T GetDefaultPageData<T>(PageReference parentPageLink, ILanguageSelector selector) where T : PageData;

        /// <summary>
        /// Saves the page without checking that the user has the necessary access rights.
        /// </summary>
        PageReference Save(PageData page, SaveAction action);

        /// <summary>
        /// Saves and publishes the page without checking that the user has the necessary access rights.
        /// </summary>
        PageReference Publish(PageData page);

        /// <summary>
        /// Deletes the specified page even if it is being linked by other pages. Does not check that the
        /// user has the necessary access rights.
        /// </summary>
        void Delete(PageData pageData);

        IEnumerable<PageReference> GetAncestors(PageData pageData);

        IEnumerable<T> GetDescendentsAccessibleToCurrentUser<T>(PageReference pageLink)  where T : PageData;

        bool TryGetPage<T>(PageReference pageLink, out T page) where T : PageData;
    }
}
