using EPiAbstractions.Core;

namespace EPiAbstractions.Opinionated
{
    public interface IEPiServerContext
    {
        IPageRepository PageRepository { get; }

        IPageReferenceFacade PageReference { get; }
    }
}
