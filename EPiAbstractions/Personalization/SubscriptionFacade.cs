using System;
using EPiServer.Core;
using EPiServer.Personalization;

namespace EPiAbstractions.Personalization
{
    public class SubscriptionFacade : ISubscriptionFacade
    {
        private static SubscriptionFacade _instance;

        public static SubscriptionFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SubscriptionFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region ISubscriptionFacade Members

        public virtual void SubscribeTo(PageReference pageLink)
        {
            Subscription.SubscribeTo(pageLink);
        }

        public virtual void SubscribeTo(PageReference pageLink, String language)
        {
            Subscription.SubscribeTo(pageLink, language);
        }

        public virtual void UnSubscribe(PageReference pageLink)
        {
            Subscription.UnSubscribe(pageLink);
        }

        public virtual void UnSubscribe(PageReference pageLink, String language)
        {
            Subscription.UnSubscribe(pageLink, language);
        }

        public virtual Boolean CanSubscribeTo(PageReference pageLink)
        {
            return Subscription.CanSubscribeTo(pageLink);
        }

        public virtual Boolean IsSubscribingTo(PageReference pageLink)
        {
            return Subscription.IsSubscribingTo(pageLink);
        }

        public virtual Boolean IsSubscribingTo(PageReference pageLink, String language)
        {
            return Subscription.IsSubscribingTo(pageLink, language);
        }

        public virtual PageReference[] ListSubscriptions()
        {
            return Subscription.ListSubscriptions();
        }

        #endregion
    }
}