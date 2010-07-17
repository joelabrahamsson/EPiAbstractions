using EPiAbstractions.Core;

namespace EPiAbstractions.Opinionated
{
    public class EPiServerContext : IEPiServerContext
    {
        private PageRepository pageRepository;
        public virtual IPageRepository PageRepository
        { 
            get
            {
                if(pageRepository == null)
                    pageRepository = new PageRepository();

                return pageRepository;
            }
        }

        private PageReferenceFacade pageReference;
        public virtual IPageReferenceFacade PageReference
        {
            get
            {
                if (pageReference == null)
                    pageReference = new PageReferenceFacade();

                return pageReference;
            }
        }
    }
}
