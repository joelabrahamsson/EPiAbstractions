using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public class PageDefinitionFacade : IPageDefinitionFacade
    {
        private static PageDefinitionFacade _instance;

        public static PageDefinitionFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PageDefinitionFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region IPageDefinitionFacade Members

        public virtual PageDefinition Load(Int32 pageDefinitionID)
        {
            return PageDefinition.Load(pageDefinitionID);
        }

        public virtual PageDefinitionCollection ListDynamic()
        {
            return PageDefinition.ListDynamic();
        }

        public virtual PageDefinitionCollection List(Int32 pageTypeID)
        {
            return PageDefinition.List(pageTypeID);
        }

        public virtual void ClearLocalCache()
        {
            PageDefinition.ClearLocalCache();
        }

        public virtual void ClearGlobalCache()
        {
            PageDefinition.ClearGlobalCache();
        }

        public virtual void Save(PageDefinition pageDefinition)
        {
            pageDefinition.Save();
        }

        public virtual void Delete(PageDefinition pageDefinition)
        {
            pageDefinition.Delete();
        }

        #endregion
    }
}