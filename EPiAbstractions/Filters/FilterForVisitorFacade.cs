using System;
using System.Collections.Generic;
using EPiAbstractions.Helpers;
using EPiServer.Core;
using EPiServer.Filters;

namespace EPiAbstractions.Filters
{
    public class FilterForVisitorFacade : IFilterForVisitorFacade
    {
        private static FilterForVisitorFacade _instance;

        public static FilterForVisitorFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FilterForVisitorFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        public virtual PageDataCollection Filter(PageDataCollection pages)
        {
            return FilterForVisitor.Filter(pages);
        }

        public IEnumerable<PageData> Filter(IEnumerable<PageData> pages)
        {
            return FilterForVisitor.Filter(pages.ToPageDataCollection());
        }
    }
}
