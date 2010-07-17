using System;
using System.Collections.Generic;
using EPiServer;
using EPiServer.Configuration;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAccess;
using EPiServer.Security;

namespace EPiAbstractions
{
    public class DataFactoryFacade : IDataFactoryFacade
    {
        private static DataFactoryFacade _instance;

        public DataFactoryFacade()
        {
            DataFactory.Instance.LoadingPage += OnLoadingPage;
            DataFactory.Instance.LoadedPage += OnLoadedPage;
            DataFactory.Instance.FinishedLoadingPage += OnFinishedLoadingPage;
            DataFactory.Instance.FailedLoadingPage += OnFailedLoadingPage;
            DataFactory.Instance.LoadingDefaultPageData += OnLoadingDefaultPageData;
            DataFactory.Instance.LoadedDefaultPageData += OnLoadedDefaultPageData;
            DataFactory.Instance.PublishingPage += OnPublishingPage;
            DataFactory.Instance.PublishedPage += OnPublishedPage;
            DataFactory.Instance.CheckingInPage += OnCheckingInPage;
            DataFactory.Instance.CheckedInPage += OnCheckedInPage;
            DataFactory.Instance.DeletingPage += OnDeletingPage;
            DataFactory.Instance.DeletedPage += OnDeletedPage;
            DataFactory.Instance.DeletingPageLanguage += OnDeletingPageLanguage;
            DataFactory.Instance.DeletedPageLanguage += OnDeletedPageLanguage;
            DataFactory.Instance.MovingPage += OnMovingPage;
            DataFactory.Instance.MovedPage += OnMovedPage;
            DataFactory.Instance.CreatingPage += OnCreatingPage;
            DataFactory.Instance.CreatedPage += OnCreatedPage;
            DataFactory.Instance.SavingPage += OnSavingPage;
            DataFactory.Instance.SavedPage += OnSavedPage;
            DataFactory.Instance.LoadingChildren += OnLoadingChildren;
            DataFactory.Instance.LoadedChildren += OnLoadedChildren;
            DataFactory.Instance.FinishedLoadingChildren += OnFinishedLoadingChildren;
            DataFactory.Instance.FailedLoadingChildren += OnFailedLoadingChildren;
        }

        public static DataFactoryFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataFactoryFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region IDataFactoryFacade Members

        public event PageEventHandler LoadingPage;
        public event PageEventHandler LoadedPage;
        public event PageEventHandler FinishedLoadingPage;
        public event PageEventHandler FailedLoadingPage;
        public event PageEventHandler LoadingDefaultPageData;
        public event PageEventHandler LoadedDefaultPageData;
        public event PageEventHandler PublishingPage;
        public event PageEventHandler PublishedPage;
        public event PageEventHandler CheckingInPage;
        public event PageEventHandler CheckedInPage;
        public event PageEventHandler DeletingPage;
        public event PageEventHandler DeletedPage;
        public event PageEventHandler DeletingPageLanguage;
        public event PageEventHandler DeletedPageLanguage;
        public event PageEventHandler MovingPage;
        public event PageEventHandler MovedPage;
        public event PageEventHandler CreatingPage;
        public event PageEventHandler CreatedPage;
        public event PageEventHandler SavingPage;
        public event PageEventHandler SavedPage;
        public event ChildrenEventHandler LoadingChildren;
        public event ChildrenEventHandler LoadedChildren;
        public event ChildrenEventHandler FinishedLoadingChildren;
        public event ChildrenEventHandler FailedLoadingChildren;

        public virtual PageProviderBase GetPageProvider(String remoteSiteName)
        {
            return DataFactory.Instance.GetPageProvider(remoteSiteName);
        }

        public virtual PageProviderBase GetPageProvider(PageReference pageLink)
        {
            return DataFactory.Instance.GetPageProvider(pageLink);
        }

        public virtual PageDataCollection GetChildren(PageReference pageLink)
        {
            return DataFactory.Instance.GetChildren(pageLink);
        }

        public virtual PageData GetPage(PageReference pageLink)
        {
            return DataFactory.Instance.GetPage(pageLink);
        }

        public virtual PagePath GetParents(PageReference pageLink)
        {
            return DataFactory.Instance.GetParents(pageLink);
        }

        public virtual IList<PageReference> GetDescendents(PageReference pageLink)
        {
            return DataFactory.Instance.GetDescendents(pageLink);
        }

        public virtual PageReferenceCollection GetLinksToPages(PageReference pageLink)
        {
            return DataFactory.Instance.GetLinksToPages(pageLink);
        }

        public virtual PageData GetDefaultPageData(PageReference parentPageLink, Int32 pageTypeID, ILanguageSelector selector)
        {
            return DataFactory.Instance.GetDefaultPageData(parentPageLink, pageTypeID, selector);
        }

        public virtual PageDataCollection GetChildren(PageReference pageLink, ILanguageSelector selector, Int32 startIndex, Int32 maxRows)
        {
            return DataFactory.Instance.GetChildren(pageLink, selector, startIndex, maxRows);
        }

        public virtual PageData GetPage(PageReference pageLink, ILanguageSelector selector)
        {
            return DataFactory.Instance.GetPage(pageLink, selector);
        }

        public virtual PageDataCollection FindPagesWithCriteria(PageReference pageLink, PropertyCriteriaCollection criterias,
                                                                String languageBranch, ILanguageSelector selector)
        {
            return DataFactory.Instance.FindPagesWithCriteria(pageLink, criterias, languageBranch, selector);
        }

        public virtual PageDataCollection FindAllPagesWithCriteria(PageReference pageLink, PropertyCriteriaCollection criterias,
                                                                   String languageBranch, ILanguageSelector selector)
        {
            return DataFactory.Instance.FindAllPagesWithCriteria(pageLink, criterias, languageBranch, selector);
        }

        public virtual PageDataCollection GetLanguageBranches(PageReference pageLink)
        {
            return DataFactory.Instance.GetLanguageBranches(pageLink);
        }

        public virtual PageData CreateLanguageBranch(PageReference pageLink, ILanguageSelector selector)
        {
            return DataFactory.Instance.CreateLanguageBranch(pageLink, selector);
        }

        public virtual void DeleteLanguageBranch(PageReference pageLink, String languageBranch)
        {
            DataFactory.Instance.DeleteLanguageBranch(pageLink, languageBranch);
        }

        public virtual void DeleteVersion(PageReference pageLink)
        {
            DataFactory.Instance.DeleteVersion(pageLink);
        }

        public virtual void Delete(PageReference pageLink, Boolean forceDelete)
        {
            DataFactory.Instance.Delete(pageLink, forceDelete);
        }

        public virtual void DeleteChildren(PageReference pageLink, Boolean forceDelete)
        {
            DataFactory.Instance.DeleteChildren(pageLink, forceDelete);
        }

        public virtual void Move(PageReference pageLink, PageReference destinationLink)
        {
            DataFactory.Instance.Move(pageLink, destinationLink);
        }

        public virtual void MoveToWastebasket(PageReference pageLink)
        {
            DataFactory.Instance.MoveToWastebasket(pageLink);
        }

        public virtual PageReference Copy(PageReference pageLink, PageReference destinationLink, Boolean publishOnDestination,
                                          Boolean allowThreading)
        {
            return DataFactory.Instance.Copy(pageLink, destinationLink, publishOnDestination, allowThreading);
        }

        public virtual PageReference Save(PageData page, SaveAction action)
        {
            return DataFactory.Instance.Save(page, action);
        }

        public virtual PageData GetDefaultPageData(PageReference parentPageLink, String pageTypeName)
        {
            return DataFactory.Instance.GetDefaultPageData(parentPageLink, pageTypeName);
        }

        public virtual PageData GetDefaultPageData(PageReference parentPageLink, Int32 pageTypeID)
        {
            return DataFactory.Instance.GetDefaultPageData(parentPageLink, pageTypeID);
        }

        public virtual PageData GetDefaultPageData(PageReference parentPageLink, String pageTypeName, ILanguageSelector selector)
        {
            return DataFactory.Instance.GetDefaultPageData(parentPageLink, pageTypeName, selector);
        }

        public virtual PageDataCollection GetChildren(PageReference pageLink, ILanguageSelector selector)
        {
            return DataFactory.Instance.GetChildren(pageLink, selector);
        }

        public virtual PageDataCollection FindPagesWithCriteria(PageReference pageLink, PropertyCriteriaCollection criterias)
        {
            return DataFactory.Instance.FindPagesWithCriteria(pageLink, criterias);
        }

        public virtual PageDataCollection FindPagesWithCriteria(PageReference pageLink, PropertyCriteriaCollection criterias,
                                                                String languageBranch)
        {
            return DataFactory.Instance.FindPagesWithCriteria(pageLink, criterias, languageBranch);
        }

        public virtual PageData CreateLanguageBranch(PageReference pageLink, ILanguageSelector selector, AccessLevel access)
        {
            return DataFactory.Instance.CreateLanguageBranch(pageLink, selector, access);
        }

        public virtual void DeleteLanguageBranch(PageReference pageLink, String languageBranch, AccessLevel access)
        {
            DataFactory.Instance.DeleteLanguageBranch(pageLink, languageBranch, access);
        }

        public virtual void Delete(PageReference pageLink, Boolean forceDelete, AccessLevel access)
        {
            DataFactory.Instance.Delete(pageLink, forceDelete, access);
        }

        public virtual void DeleteVersion(PageReference pageLink, AccessLevel access)
        {
            DataFactory.Instance.DeleteVersion(pageLink, access);
        }

        public virtual void DeleteChildren(PageReference pageLink, Boolean forceDelete, AccessLevel access)
        {
            DataFactory.Instance.DeleteChildren(pageLink, forceDelete, access);
        }

        public virtual void Move(PageReference pageLink, PageReference destinationLink, AccessLevel requiredSourceAccess,
                                 AccessLevel requiredDestinationAccess)
        {
            DataFactory.Instance.Move(pageLink, destinationLink, requiredSourceAccess, requiredDestinationAccess);
        }

        public virtual PageReference Copy(PageReference pageLink, PageReference destinationLink, AccessLevel requiredSourceAccess,
                                          AccessLevel requiredDestinationAccess, Boolean publishOnDestination, Boolean allowThreading)
        {
            return DataFactory.Instance.Copy(pageLink, destinationLink, requiredSourceAccess, requiredDestinationAccess,
                                             publishOnDestination, allowThreading);
        }

        public virtual PageReference Copy(PageReference pageLink, PageReference destinationLink)
        {
            return DataFactory.Instance.Copy(pageLink, destinationLink);
        }

        public virtual PageReference Copy(PageReference pageLink, PageReference destinationLink, Boolean allowThreading)
        {
            return DataFactory.Instance.Copy(pageLink, destinationLink, allowThreading);
        }

        public virtual PageReference Save(PageData page, SaveAction action, AccessLevel access)
        {
            return DataFactory.Instance.Save(page, action, access);
        }

        public virtual Settings GetSettingsFromPage(PageReference pageLink)
        {
            return DataFactory.Instance.GetSettingsFromPage(pageLink);
        }

        public virtual Boolean IsCapabilitySupported(PageReference pageLink, PageProviderCapabilities capability)
        {
            return DataFactory.Instance.IsCapabilitySupported(pageLink, capability);
        }

        public virtual Boolean IsWastebasket(PageReference pageLink)
        {
            return DataFactory.Instance.IsWastebasket(pageLink);
        }

        public virtual void ResetCounters()
        {
            DataFactory.Instance.ResetCounters();
        }

        public virtual PageVersionCollection ListVersions(PageReference pageLink)
        {
            return DataFactory.Instance.ListVersions(pageLink);
        }

        public virtual PageVersionCollection ListVersions(PageReference pageLink, String languageBranch)
        {
            return DataFactory.Instance.ListVersions(pageLink, languageBranch);
        }

        public virtual PageVersionCollection ListPublishedVersions(PageReference pageLink)
        {
            return DataFactory.Instance.ListPublishedVersions(pageLink);
        }

        public virtual PageVersion LoadVersion(PageReference pageLink)
        {
            return DataFactory.Instance.LoadVersion(pageLink);
        }

        public virtual PageVersion LoadPublishedVersion(PageReference pageLink)
        {
            return DataFactory.Instance.LoadPublishedVersion(pageLink);
        }

        public virtual PageVersion LoadPublishedVersion(PageReference pageLink, String languageBranch)
        {
            return DataFactory.Instance.LoadPublishedVersion(pageLink, languageBranch);
        }

        public virtual PageDataCollection ListDelayedPublish()
        {
            return DataFactory.Instance.ListDelayedPublish();
        }
        #endregion

        public virtual void OnLoadingPage(Object sender, PageEventArgs e)
        {
            if (LoadingPage != null)
                LoadingPage(sender, e);
        }

        public virtual void OnLoadedPage(Object sender, PageEventArgs e)
        {
            if (LoadedPage != null)
                LoadedPage(sender, e);
        }

        public virtual void OnFinishedLoadingPage(Object sender, PageEventArgs e)
        {
            if (FinishedLoadingPage != null)
                FinishedLoadingPage(sender, e);
        }

        public virtual void OnFailedLoadingPage(Object sender, PageEventArgs e)
        {
            if (FailedLoadingPage != null)
                FailedLoadingPage(sender, e);
        }

        public virtual void OnLoadingDefaultPageData(Object sender, PageEventArgs e)
        {
            if (LoadingDefaultPageData != null)
                LoadingDefaultPageData(sender, e);
        }

        public virtual void OnLoadedDefaultPageData(Object sender, PageEventArgs e)
        {
            if (LoadedDefaultPageData != null)
                LoadedDefaultPageData(sender, e);
        }

        public virtual void OnPublishingPage(Object sender, PageEventArgs e)
        {
            if (PublishingPage != null)
                PublishingPage(sender, e);
        }

        public virtual void OnPublishedPage(Object sender, PageEventArgs e)
        {
            if (PublishedPage != null)
                PublishedPage(sender, e);
        }

        public virtual void OnCheckingInPage(Object sender, PageEventArgs e)
        {
            if (CheckingInPage != null)
                CheckingInPage(sender, e);
        }

        public virtual void OnCheckedInPage(Object sender, PageEventArgs e)
        {
            if (CheckedInPage != null)
                CheckedInPage(sender, e);
        }

        public virtual void OnDeletingPage(Object sender, PageEventArgs e)
        {
            if (DeletingPage != null)
                DeletingPage(sender, e);
        }

        public virtual void OnDeletedPage(Object sender, PageEventArgs e)
        {
            if (DeletedPage != null)
                DeletedPage(sender, e);
        }

        public virtual void OnDeletingPageLanguage(Object sender, PageEventArgs e)
        {
            if (DeletingPageLanguage != null)
                DeletingPageLanguage(sender, e);
        }

        public virtual void OnDeletedPageLanguage(Object sender, PageEventArgs e)
        {
            if (DeletedPageLanguage != null)
                DeletedPageLanguage(sender, e);
        }

        public virtual void OnMovingPage(Object sender, PageEventArgs e)
        {
            if (MovingPage != null)
                MovingPage(sender, e);
        }

        public virtual void OnMovedPage(Object sender, PageEventArgs e)
        {
            if (MovedPage != null)
                MovedPage(sender, e);
        }

        public virtual void OnCreatingPage(Object sender, PageEventArgs e)
        {
            if (CreatingPage != null)
                CreatingPage(sender, e);
        }

        public virtual void OnCreatedPage(Object sender, PageEventArgs e)
        {
            if (CreatedPage != null)
                CreatedPage(sender, e);
        }

        public virtual void OnSavingPage(Object sender, PageEventArgs e)
        {
            if (SavingPage != null)
                SavingPage(sender, e);
        }

        public virtual void OnSavedPage(Object sender, PageEventArgs e)
        {
            if (SavedPage != null)
                SavedPage(sender, e);
        }

        public virtual void OnLoadingChildren(Object sender, ChildrenEventArgs e)
        {
            if (LoadingChildren != null)
                LoadingChildren(sender, e);
        }

        public virtual void OnLoadedChildren(Object sender, ChildrenEventArgs e)
        {
            if (LoadedChildren != null)
                LoadedChildren(sender, e);
        }

        public virtual void OnFinishedLoadingChildren(Object sender, ChildrenEventArgs e)
        {
            if (FinishedLoadingChildren != null)
                FinishedLoadingChildren(sender, e);
        }

        public virtual void OnFailedLoadingChildren(Object sender, ChildrenEventArgs e)
        {
            if (FailedLoadingChildren != null)
                FailedLoadingChildren(sender, e);
        }

        public PageData CurrentPage
        {
            get { return DataFactory.Instance.CurrentPage; }
        }
    }
}