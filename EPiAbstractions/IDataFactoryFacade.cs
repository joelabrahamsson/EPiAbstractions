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
    public interface IDataFactoryFacade : IPageSource
    {
        PageProviderBase GetPageProvider(String remoteSiteName);

        PageProviderBase GetPageProvider(PageReference pageLink);

        PageDataCollection GetChildren(PageReference pageLink);

        PageData GetPage(PageReference pageLink);

        PagePath GetParents(PageReference pageLink);

        IList<PageReference> GetDescendents(PageReference pageLink);

        PageReferenceCollection GetLinksToPages(PageReference pageLink);

        PageData GetDefaultPageData(PageReference parentPageLink, Int32 pageTypeID, ILanguageSelector selector);

        PageDataCollection GetChildren(PageReference pageLink, ILanguageSelector selector, Int32 startIndex, Int32 maxRows);

        PageData GetPage(PageReference pageLink, ILanguageSelector selector);

        PageDataCollection FindPagesWithCriteria(PageReference pageLink, PropertyCriteriaCollection criterias, String languageBranch,
                                                 ILanguageSelector selector);

        PageDataCollection FindAllPagesWithCriteria(PageReference pageLink, PropertyCriteriaCollection criterias, String languageBranch,
                                                    ILanguageSelector selector);

        PageDataCollection GetLanguageBranches(PageReference pageLink);

        PageData CreateLanguageBranch(PageReference pageLink, ILanguageSelector selector);

        void DeleteLanguageBranch(PageReference pageLink, String languageBranch);

        void DeleteVersion(PageReference pageLink);

        void Delete(PageReference pageLink, Boolean forceDelete);

        void DeleteChildren(PageReference pageLink, Boolean forceDelete);

        void Move(PageReference pageLink, PageReference destinationLink);

        void MoveToWastebasket(PageReference pageLink);

        PageReference Copy(PageReference pageLink, PageReference destinationLink, Boolean publishOnDestination, Boolean allowThreading);

        PageReference Save(PageData page, SaveAction action);

        PageData GetDefaultPageData(PageReference parentPageLink, String pageTypeName);

        PageData GetDefaultPageData(PageReference parentPageLink, Int32 pageTypeID);

        PageData GetDefaultPageData(PageReference parentPageLink, String pageTypeName, ILanguageSelector selector);

        PageDataCollection GetChildren(PageReference pageLink, ILanguageSelector selector);

        PageDataCollection FindPagesWithCriteria(PageReference pageLink, PropertyCriteriaCollection criterias);

        PageDataCollection FindPagesWithCriteria(PageReference pageLink, PropertyCriteriaCollection criterias, String languageBranch);

        PageData CreateLanguageBranch(PageReference pageLink, ILanguageSelector selector, AccessLevel access);

        void DeleteLanguageBranch(PageReference pageLink, String languageBranch, AccessLevel access);

        void Delete(PageReference pageLink, Boolean forceDelete, AccessLevel access);

        void DeleteVersion(PageReference pageLink, AccessLevel access);

        void DeleteChildren(PageReference pageLink, Boolean forceDelete, AccessLevel access);

        void Move(PageReference pageLink, PageReference destinationLink, AccessLevel requiredSourceAccess,
                  AccessLevel requiredDestinationAccess);

        PageReference Copy(PageReference pageLink, PageReference destinationLink, AccessLevel requiredSourceAccess,
                           AccessLevel requiredDestinationAccess, Boolean publishOnDestination, Boolean allowThreading);

        PageReference Copy(PageReference pageLink, PageReference destinationLink);

        PageReference Copy(PageReference pageLink, PageReference destinationLink, Boolean allowThreading);

        PageReference Save(PageData page, SaveAction action, AccessLevel access);

        Settings GetSettingsFromPage(PageReference pageLink);

        Boolean IsCapabilitySupported(PageReference pageLink, PageProviderCapabilities capability);

        Boolean IsWastebasket(PageReference pageLink);

        void ResetCounters();

        PageVersionCollection ListVersions(PageReference pageLink);

        PageVersionCollection ListVersions(PageReference pageLink, String languageBranch);

        PageVersionCollection ListPublishedVersions(PageReference pageLink);

        PageVersion LoadVersion(PageReference pageLink);

        PageVersion LoadPublishedVersion(PageReference pageLink);

        PageVersion LoadPublishedVersion(PageReference pageLink, String languageBranch);

        PageDataCollection ListDelayedPublish();

        event PageEventHandler LoadingPage;

        event PageEventHandler LoadedPage;

        event PageEventHandler FinishedLoadingPage;

        event PageEventHandler FailedLoadingPage;

        event PageEventHandler LoadingDefaultPageData;

        event PageEventHandler LoadedDefaultPageData;

        event PageEventHandler PublishingPage;

        event PageEventHandler PublishedPage;

        event PageEventHandler CheckingInPage;

        event PageEventHandler CheckedInPage;

        event PageEventHandler DeletingPage;

        event PageEventHandler DeletedPage;

        event PageEventHandler DeletingPageLanguage;

        event PageEventHandler DeletedPageLanguage;

        event PageEventHandler MovingPage;

        event PageEventHandler MovedPage;

        event PageEventHandler CreatingPage;

        event PageEventHandler CreatedPage;

        event PageEventHandler SavingPage;

        event PageEventHandler SavedPage;

        event ChildrenEventHandler LoadingChildren;

        event ChildrenEventHandler LoadedChildren;

        event ChildrenEventHandler FinishedLoadingChildren;

        event ChildrenEventHandler FailedLoadingChildren;
    }
}