using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public class PageTypeFacade : IPageTypeFacade
    {
        private static PageTypeFacade _instance;

        public static PageTypeFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PageTypeFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region IPageTypeFacade Members

        public virtual PageType Load(Int32 id)
        {
            return PageType.Load(id);
        }

        public virtual PageType Load(String name)
        {
            return PageType.Load(name);
        }

        public virtual PageType Load(Guid guid)
        {
            return PageType.Load(guid);
        }

        public virtual PageTypeCollection List()
        {
            return PageType.List();
        }

        public virtual void ClearCache()
        {
            PageType.ClearCache();
        }

        public virtual void Save(PageType pageType)
        {
            pageType.Save();
        }

        public virtual void Delete(PageType pageType)
        {
            pageType.Delete();
        }

        #endregion
    }
}