using System;
using EPiServer.Core;
using EPiServer.Web.Hosting;

namespace EPiAbstractions.Web.Hosting
{
    public interface IUnifiedDirectoryFacade
    {
        event UnifiedDirectoryEventHandler UnifiedDirectoryAdded;

        event UnifiedDirectoryEventHandler UnifiedFileAdded;

        event UnifiedDirectoryEventHandler UnifiedDirectoryMoved;

        event UnifiedDirectoryEventHandler UnifiedDirectoryCopied;

        event UnifiedDirectoryEventHandler UnifiedDirectoryDeleted;

        event UnifiedDirectoryEventHandler UnifiedDirectoryAdding;

        event UnifiedDirectoryEventHandler UnifiedFileAdding;

        event UnifiedDirectoryEventHandler UnifiedDirectoryMoving;

        event UnifiedDirectoryEventHandler UnifiedDirectoryCopying;

        event UnifiedDirectoryEventHandler UnifiedDirectoryDeleting;

        PageData GetOwnerPageFromVirtualPath(String virtualPath);

        Boolean TryParsePageFolder(String virtualPath, out Int32 pageFolderId);

        UnifiedDirectory CreateDirectory(String virtualPath);

        String GetDirectoryNameFromVirtualPath(String virtualPath);

        void UnInitialize();
    }
}