using System;
using EPiServer.Core;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public class PageVersionFacade : IPageVersionFacade
    {
        private static PageVersionFacade _instance;

        public static PageVersionFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PageVersionFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region IPageVersionFacade Members

        public virtual PageVersionCollection List(PageReference pageLink, String languageBranch)
        {
            return PageVersion.List(pageLink, languageBranch);
        }

        public virtual PageVersionCollection List(PageReference pageLink)
        {
            return PageVersion.List(pageLink);
        }

        public virtual PageDataCollection ListDelayedPublish()
        {
            return PageVersion.ListDelayedPublish();
        }

        public virtual PageVersion LoadPublishedVersion(PageReference pageLink, String languageBranch)
        {
            return PageVersion.LoadPublishedVersion(pageLink, languageBranch);
        }

        public virtual PageVersionCollection ListPublishedVersions(PageReference pageLink)
        {
            return PageVersion.ListPublishedVersions(pageLink);
        }

        public virtual PageVersion LoadPublishedVersion(PageReference pageLink)
        {
            return PageVersion.LoadPublishedVersion(pageLink);
        }

        public virtual PageVersion Load(PageReference pageLink)
        {
            return PageVersion.Load(pageLink);
        }

        #endregion
    }
}