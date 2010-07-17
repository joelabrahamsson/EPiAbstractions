using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public interface IPageDefinitionFacade
    {
        PageDefinition Load(Int32 pageDefinitionID);

        PageDefinitionCollection ListDynamic();

        PageDefinitionCollection List(Int32 pageTypeID);

        void Save(PageDefinition pageDefinition);

        void Delete(PageDefinition pageDefinition);

        void ClearLocalCache();

        void ClearGlobalCache();
    }
}