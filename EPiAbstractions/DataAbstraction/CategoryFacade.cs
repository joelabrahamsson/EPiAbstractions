using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public class CategoryFacade : ICategoryFacade
    {
        private static CategoryFacade _instance;

        public static CategoryFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CategoryFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region ICategoryFacade Members

        public virtual Category GetRoot()
        {
            return Category.GetRoot();
        }

        public virtual Category Find(Int32 id)
        {
            return Category.Find(id);
        }

        public virtual Category Find(String name)
        {
            return Category.Find(name);
        }

        public virtual void Save(Category category)
        {
            category.Save();
        }

        public virtual void Delete(Category category)
        {
            category.Delete();
        }

        #endregion
    }
}