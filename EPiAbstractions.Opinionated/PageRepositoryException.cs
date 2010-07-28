using System;

namespace EPiAbstractions.Opinionated
{
    [Serializable]
    public class PageRepositoryException : Exception
    {
        public PageRepositoryException(string message)
            : base(message) {}
    }
}
