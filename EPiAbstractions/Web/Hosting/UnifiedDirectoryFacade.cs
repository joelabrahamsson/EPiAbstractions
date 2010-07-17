using System;
using EPiServer.Core;
using EPiServer.Web.Hosting;

namespace EPiAbstractions.Web.Hosting
{
    public class UnifiedDirectoryFacade : IUnifiedDirectoryFacade
    {
        private static UnifiedDirectoryFacade _instance;

        public UnifiedDirectoryFacade()
        {
            UnifiedDirectory.UnifiedDirectoryAdded += OnUnifiedDirectoryAdded;
            UnifiedDirectory.UnifiedFileAdded += OnUnifiedFileAdded;
            UnifiedDirectory.UnifiedDirectoryMoved += OnUnifiedDirectoryMoved;
            UnifiedDirectory.UnifiedDirectoryCopied += OnUnifiedDirectoryCopied;
            UnifiedDirectory.UnifiedDirectoryDeleted += OnUnifiedDirectoryDeleted;
            UnifiedDirectory.UnifiedDirectoryAdding += OnUnifiedDirectoryAdding;
            UnifiedDirectory.UnifiedFileAdding += OnUnifiedFileAdding;
            UnifiedDirectory.UnifiedDirectoryMoving += OnUnifiedDirectoryMoving;
            UnifiedDirectory.UnifiedDirectoryCopying += OnUnifiedDirectoryCopying;
            UnifiedDirectory.UnifiedDirectoryDeleting += OnUnifiedDirectoryDeleting;
        }

        public static UnifiedDirectoryFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UnifiedDirectoryFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region IUnifiedDirectoryFacade Members

        public event UnifiedDirectoryEventHandler UnifiedDirectoryAdded;
        public event UnifiedDirectoryEventHandler UnifiedFileAdded;
        public event UnifiedDirectoryEventHandler UnifiedDirectoryMoved;
        public event UnifiedDirectoryEventHandler UnifiedDirectoryCopied;
        public event UnifiedDirectoryEventHandler UnifiedDirectoryDeleted;
        public event UnifiedDirectoryEventHandler UnifiedDirectoryAdding;
        public event UnifiedDirectoryEventHandler UnifiedFileAdding;
        public event UnifiedDirectoryEventHandler UnifiedDirectoryMoving;
        public event UnifiedDirectoryEventHandler UnifiedDirectoryCopying;
        public event UnifiedDirectoryEventHandler UnifiedDirectoryDeleting;

        public virtual PageData GetOwnerPageFromVirtualPath(String virtualPath)
        {
            return UnifiedDirectory.GetOwnerPageFromVirtualPath(virtualPath);
        }

        public virtual Boolean TryParsePageFolder(String virtualPath, out Int32 pageFolderId)
        {
            return UnifiedDirectory.TryParsePageFolder(virtualPath, out pageFolderId);
        }

        public virtual UnifiedDirectory CreateDirectory(String virtualPath)
        {
            return UnifiedDirectory.CreateDirectory(virtualPath);
        }

        public virtual String GetDirectoryNameFromVirtualPath(String virtualPath)
        {
            return UnifiedDirectory.GetDirectoryNameFromVirtualPath(virtualPath);
        }

        public virtual void UnInitialize()
        {
            UnifiedDirectory.UnInitialize();
        }

        #endregion

        public virtual void OnUnifiedDirectoryAdded(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedDirectoryAdded != null)
                UnifiedDirectoryAdded(sender, e);
        }

        public virtual void OnUnifiedFileAdded(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileAdded != null)
                UnifiedFileAdded(sender, e);
        }

        public virtual void OnUnifiedDirectoryMoved(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedDirectoryMoved != null)
                UnifiedDirectoryMoved(sender, e);
        }

        public virtual void OnUnifiedDirectoryCopied(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedDirectoryCopied != null)
                UnifiedDirectoryCopied(sender, e);
        }

        public virtual void OnUnifiedDirectoryDeleted(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedDirectoryDeleted != null)
                UnifiedDirectoryDeleted(sender, e);
        }

        public virtual void OnUnifiedDirectoryAdding(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedDirectoryAdding != null)
                UnifiedDirectoryAdding(sender, e);
        }

        public virtual void OnUnifiedFileAdding(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedFileAdding != null)
                UnifiedFileAdding(sender, e);
        }

        public virtual void OnUnifiedDirectoryMoving(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedDirectoryMoving != null)
                UnifiedDirectoryMoving(sender, e);
        }

        public virtual void OnUnifiedDirectoryCopying(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedDirectoryCopying != null)
                UnifiedDirectoryCopying(sender, e);
        }

        public virtual void OnUnifiedDirectoryDeleting(UnifiedDirectory sender, UnifiedVirtualPathEventArgs e)
        {
            if (UnifiedDirectoryDeleting != null)
                UnifiedDirectoryDeleting(sender, e);
        }
    }
}