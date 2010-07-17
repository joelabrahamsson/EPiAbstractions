using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using EPiServer.DataAbstraction;
using EPiServer.Security;

namespace EPiAbstractions.DataAbstraction
{
    public class UnifiedPathInfoFacade : IUnifiedPathInfoFacade
    {
        private static UnifiedPathInfoFacade _instance;

        public static UnifiedPathInfoFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UnifiedPathInfoFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region IUnifiedPathInfoFacade Members

        public virtual Boolean IsAccessAllowed(String userPath)
        {
            return UnifiedPathInfo.IsAccessAllowed(userPath);
        }

        public virtual Boolean IsAccessAllowed(String userPath, IPrincipal principal)
        {
            return UnifiedPathInfo.IsAccessAllowed(userPath, principal);
        }

        public virtual UnifiedPathInfo Load(String path)
        {
            return UnifiedPathInfo.Load(path);
        }

        public virtual StringCollection Search(String path, IDictionary<string, string> search)
        {
            return UnifiedPathInfo.Search(path, search);
        }

        public virtual void ClearAclForMembership(String userOrRoleName, SecurityEntityType securityEntityType)
        {
            UnifiedPathInfo.ClearAclForMembership(userOrRoleName, securityEntityType);
        }

        public virtual void MoveAll(String fromPath, String toPath)
        {
            UnifiedPathInfo.MoveAll(fromPath, toPath);
        }

        public virtual void DeleteAll()
        {
            UnifiedPathInfo.DeleteAll();
        }

        public virtual void ClearCache()
        {
            UnifiedPathInfo.ClearCache();
        }

        public virtual UnifiedPathInfo GetQualifiedUnifiedPathInfo(String virtualPath)
        {
            return UnifiedPathInfo.GetQualifiedUnifiedPathInfo(virtualPath);
        }

        public virtual void Save(UnifiedPathInfo unifiedPathInfo)
        {
            unifiedPathInfo.Save();
        }

        public virtual void Delete(UnifiedPathInfo unifiedPathInfo)
        {
            unifiedPathInfo.Delete();
        }

        #endregion
    }
}