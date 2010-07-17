using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public interface ITabDefinitionFacade
    {
        TabDefinition Load(Int32 id);

        TabDefinition Load(String name);

        TabDefinitionCollection List();

        void Save(TabDefinition tabDefinition);

        void Delete(TabDefinition tabDefinition);

        void ClearCache();

        String[] GetDependentPropertyNames(Int32 tabId);
    }
}