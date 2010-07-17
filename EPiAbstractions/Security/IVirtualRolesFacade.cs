using System;
using System.Security.Principal;

namespace EPiAbstractions.Security
{
    public interface IVirtualRolesFacade
    {
        String GetRoleNameForClass(Type classType);

        String[] GetAllVirtualRoles();

        String[] GetAllRoles();

        String[] GetAllRolesForUser(String username);

        Boolean IsPrincipalInVirtualRole(IPrincipal principal, String virtualRole, Object context);
    }
}