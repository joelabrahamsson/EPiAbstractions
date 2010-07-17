using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public interface ICategoryFacade
    {
        Category GetRoot();

        Category Find(Int32 id);

        Category Find(String name);

        void Save(Category category);

        void Delete(Category category);
    }
}