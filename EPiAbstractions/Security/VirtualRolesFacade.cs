using System;
using System.Security.Principal;
using EPiServer.Security;

namespace EPiAbstractions.Security
{
    public class VirtualRolesFacade : IVirtualRolesFacade
    {
        private static VirtualRolesFacade _instance;

        public static VirtualRolesFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new VirtualRolesFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region IVirtualRolesFacade Members

        public virtual String GetRoleNameForClass(Type classType)
        {
            return VirtualRoles.GetRoleNameForClass(classType);
        }

        public virtual String[] GetAllVirtualRoles()
        {
            return VirtualRoles.GetAllVirtualRoles();
        }

        public virtual String[] GetAllRoles()
        {
            return VirtualRoles.GetAllRoles();
        }

        public virtual String[] GetAllRolesForUser(String username)
        {
            return VirtualRoles.GetAllRolesForUser(username);
        }

        public virtual Boolean IsPrincipalInVirtualRole(IPrincipal principal, String virtualRole, Object context)
        {
            return VirtualRoles.IsPrincipalInVirtualRole(principal, virtualRole, context);
        }

        #endregion
    }
}