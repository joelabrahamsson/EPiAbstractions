using System;
using System.Web.Hosting;
using EPiServer.Web.Hosting;

namespace EPiAbstractions.Web.Hosting
{
    public class UnifiedFileFacade : IUnifiedFileFacade
    {
        private static UnifiedFileFacade _instance;

        public UnifiedFileFacade()
        {
            UnifiedFile.UnifiedFileChanged += OnUnifiedFileChanged;
            UnifiedFile.UnifiedFileMoved += OnUnifiedFileMoved;
            UnifiedFile.UnifiedFileCopied += OnUnifiedFileCopied;
            UnifiedFile.UnifiedFileCheckedOut += OnUnifiedFileCheckedOut;
            UnifiedFile.UnifiedFileCheckedIn += OnUnifiedFileCheckedIn;
            UnifiedFile.UnifiedFileUndoedCheckOut += OnUnifiedFileUndoedCheckOut;
            UnifiedFile.UnifiedFileDeleted += OnUnifiedFileDeleted;
            UnifiedFile.UnifiedFileMoving += OnUnifiedFileMoving;
            UnifiedFile.UnifiedFileCopying += OnUnifiedFileCopying;
            UnifiedFile.UnifiedFileCheckingOut += OnUnifiedFileCheckingOut;
            UnifiedFile.UnifiedFileCheckingIn += OnUnifiedFileCheckingIn;
            UnifiedFile.UnifiedFileUndoingCheckOut += OnUnifiedFileUndoingCheckOut;
            UnifiedFile.UnifiedFileDeleting += OnUnifiedFileDeleting;
            UnifiedFile.UnifiedFileTransmitting += OnUnifiedFileTransmitting;
        }

        public static UnifiedFileFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UnifiedFileFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region IUnifiedFileFacade Members

        public event UnifiedFileStreamEventHandler UnifiedFileChanged;
        public event UnifiedFileEventHandler UnifiedFileMoved;
        public event UnifiedFileEventHandler UnifiedFileCopied;
        public event UnifiedFileEventHandler UnifiedFileCheckedOut;
        public event UnifiedFileEventHandler UnifiedFileCheckedIn;
        public event UnifiedFileEventHandler UnifiedFileUndoedCheckOut;
        public event UnifiedFileEventHandler UnifiedFileDeleted;
        public event UnifiedFileEventHandler UnifiedFileMoving;
        public event UnifiedFileEventHandler UnifiedFileCopying;
        public event UnifiedFileEventHandler UnifiedFileCheckingOut;
        public event UnifiedFileEventHandler UnifiedFileCheckingIn;
        public event UnifiedFileEventHandler UnifiedFileUndoingCheckOut;
        public event UnifiedFileEventHandler UnifiedFileDeleting;
        public event UnifiedFileEventHandler UnifiedFileTransmitting;

        public virtual Boolean OnTransmitting(VirtualFile file)
        {
            return UnifiedFile.OnTransmitting(file);
        }

        public virtual void MoveTo(UnifiedFile source, String newVirtualPath)
        {
            UnifiedFile.MoveTo(source, newVirtualPath);
        }

        public virtual void CopyTo(VirtualFile source, String newVirtualPath)
        {
            UnifiedFile.CopyTo(source, newVirtualPath);
        }

        public virtual void CopySummary(UnifiedFile src, UnifiedFile dst)
        {
            UnifiedFile.CopySummary(src, dst);
        }

        #endregion

        public virtual void OnUnifiedFileChanged(UnifiedFileStream sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileChanged != null)
                UnifiedFileChanged(sender, e);
        }

        public virtual void OnUnifiedFileMoved(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileMoved != null)
                UnifiedFileMoved(sender, e);
        }

        public virtual void OnUnifiedFileCopied(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileCopied != null)
                UnifiedFileCopied(sender, e);
        }

        public virtual void OnUnifiedFileCheckedOut(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileCheckedOut != null)
                UnifiedFileCheckedOut(sender, e);
        }

        public virtual void OnUnifiedFileCheckedIn(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileCheckedIn != null)
                UnifiedFileCheckedIn(sender, e);
        }

        public virtual void OnUnifiedFileUndoedCheckOut(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileUndoedCheckOut != null)
                UnifiedFileUndoedCheckOut(sender, e);
        }

        public virtual void OnUnifiedFileDeleted(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileDeleted != null)
                UnifiedFileDeleted(sender, e);
        }

        public virtual void OnUnifiedFileMoving(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileMoving != null)
                UnifiedFileMoving(sender, e);
        }

        public virtual void OnUnifiedFileCopying(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileCopying != null)
                UnifiedFileCopying(sender, e);
        }

        public virtual void OnUnifiedFileCheckingOut(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileCheckingOut != null)
                UnifiedFileCheckingOut(sender, e);
        }

        public virtual void OnUnifiedFileCheckingIn(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileCheckingIn != null)
                UnifiedFileCheckingIn(sender, e);
        }

        public virtual void OnUnifiedFileUndoingCheckOut(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileUndoingCheckOut != null)
                UnifiedFileUndoingCheckOut(sender, e);
        }

        public virtual void OnUnifiedFileDeleting(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileDeleting != null)
                UnifiedFileDeleting(sender, e);
        }

        public virtual void OnUnifiedFileTransmitting(UnifiedFile sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileTransmitting != null)
                UnifiedFileTransmitting(sender, e);
        }
    }
}