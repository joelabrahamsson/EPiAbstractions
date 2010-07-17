using System;

namespace EPiAbstractions.Opinionated
{
    public class PageRepositoryException : Exception
    {
        public PageRepositoryException(string message)
            : base(message) {}
    }
}
