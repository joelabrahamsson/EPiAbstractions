using System;
using EPiServer.Core;

namespace EPiAbstractions.Personalization
{
    public interface ISubscriptionFacade
    {
        void SubscribeTo(PageReference pageLink);

        void SubscribeTo(PageReference pageLink, String language);

        void UnSubscribe(PageReference pageLink);

        void UnSubscribe(PageReference pageLink, String language);

        Boolean CanSubscribeTo(PageReference pageLink);

        Boolean IsSubscribingTo(PageReference pageLink);

        Boolean IsSubscribingTo(PageReference pageLink, String language);

        PageReference[] ListSubscriptions();
    }
}