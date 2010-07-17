using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public interface IPageTypeFacade
    {
        PageType Load(Int32 id);

        PageType Load(String name);

        PageType Load(Guid guid);

        PageTypeCollection List();

        void Save(PageType pageType);

        void Delete(PageType pageType);

        void ClearCache();
    }
}