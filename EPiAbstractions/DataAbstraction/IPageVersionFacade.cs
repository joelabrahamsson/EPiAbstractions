using System;
using EPiServer.Core;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public interface IPageVersionFacade
    {
        PageVersionCollection List(PageReference pageLink, String languageBranch);

        PageVersionCollection List(PageReference pageLink);

        PageDataCollection ListDelayedPublish();

        PageVersion LoadPublishedVersion(PageReference pageLink, String languageBranch);

        PageVersionCollection ListPublishedVersions(PageReference pageLink);

        PageVersion LoadPublishedVersion(PageReference pageLink);

        PageVersion Load(PageReference pageLink);
    }
}