using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public class TabDefinitionFacade : ITabDefinitionFacade
    {
        private static TabDefinitionFacade _instance;

        public static TabDefinitionFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TabDefinitionFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region ITabDefinitionFacade Members

        public virtual TabDefinition Load(Int32 id)
        {
            return TabDefinition.Load(id);
        }

        public virtual TabDefinition Load(String name)
        {
            return TabDefinition.Load(name);
        }

        public virtual TabDefinitionCollection List()
        {
            return TabDefinition.List();
        }

        public virtual void ClearCache()
        {
            TabDefinition.ClearCache();
        }

        public virtual String[] GetDependentPropertyNames(Int32 tabId)
        {
            return TabDefinition.GetDependentPropertyNames(tabId);
        }

        public virtual void Save(TabDefinition tabDefinition)
        {
            tabDefinition.Save();
        }

        public virtual void Delete(TabDefinition tabDefinition)
        {
            tabDefinition.Delete();
        }

        #endregion
    }
}