using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using EPiServer.DataAbstraction;
using EPiServer.Security;

namespace EPiAbstractions.DataAbstraction
{
    public interface IUnifiedPathInfoFacade
    {
        Boolean IsAccessAllowed(String userPath);

        Boolean IsAccessAllowed(String userPath, IPrincipal principal);

        UnifiedPathInfo Load(String path);

        StringCollection Search(String path, IDictionary<string, string> search);

        void ClearAclForMembership(String userOrRoleName, SecurityEntityType securityEntityType);

        void MoveAll(String fromPath, String toPath);

        void DeleteAll();

        void ClearCache();

        UnifiedPathInfo GetQualifiedUnifiedPathInfo(String virtualPath);

        void Save(UnifiedPathInfo unifiedPathInfo);

        void Delete(UnifiedPathInfo unifiedPathInfo);
    }
}