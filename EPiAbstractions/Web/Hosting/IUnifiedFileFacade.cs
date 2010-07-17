using System;
using System.Web.Hosting;
using EPiServer.Web.Hosting;

namespace EPiAbstractions.Web.Hosting
{
    public interface IUnifiedFileFacade
    {
        event UnifiedFileStreamEventHandler UnifiedFileChanged;

        event UnifiedFileEventHandler UnifiedFileMoved;

        event UnifiedFileEventHandler UnifiedFileCopied;

        event UnifiedFileEventHandler UnifiedFileCheckedOut;

        event UnifiedFileEventHandler UnifiedFileCheckedIn;

        event UnifiedFileEventHandler UnifiedFileUndoedCheckOut;

        event UnifiedFileEventHandler UnifiedFileDeleted;

        event UnifiedFileEventHandler UnifiedFileMoving;

        event UnifiedFileEventHandler UnifiedFileCopying;

        event UnifiedFileEventHandler UnifiedFileCheckingOut;

        event UnifiedFileEventHandler UnifiedFileCheckingIn;

        event UnifiedFileEventHandler UnifiedFileUndoingCheckOut;

        event UnifiedFileEventHandler UnifiedFileDeleting;

        event UnifiedFileEventHandler UnifiedFileTransmitting;

        Boolean OnTransmitting(VirtualFile file);

        void MoveTo(UnifiedFile source, String newVirtualPath);

        void CopyTo(VirtualFile source, String newVirtualPath);

        void CopySummary(UnifiedFile src, UnifiedFile dst);
    }
}