using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using Libretto.Model;
using LibrettoWCF.Database;

namespace LibrettoWCF.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomPrincipal : IPrincipal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userIdentity"></param>
        public CustomPrincipal(IIdentity userIdentity)
        {
            Identity = userIdentity;
        }

        /// <summary>
        /// 
        /// </summary>
        private string[] _roles;

        /// <summary>
        /// 
        /// </summary>
        public IIdentity Identity
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public static CustomPrincipal Current => Thread.CurrentPrincipal as CustomPrincipal;

        /// <summary>
        /// 
        /// </summary>
        public string[] Roles
        {
            get
            {
                if (_roles == null)
                {
                    EnsureRoles();
                }

                return _roles;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            if (role == null)
            {
                return false;
            }

            if (_roles == null)
            {
                EnsureRoles();
            }

            return _roles.Any(rl => rl == role);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void EnsureRoles()
        {
            var clerkInformation = LibrettoDatabase.ClerkIntegration.LookupByEmail(Identity.Name);

            if (clerkInformation == null)
            {
                _roles = new[]
                {
                    Permissions.None.ToString()
                };
            }
            else if (clerkInformation.Permissions == Permissions.Administrator)
            {
                _roles = new[]
                {
                    Permissions.Clerk.ToString(),
                    Permissions.Administrator.ToString()
                };
            }
            else
            {
                _roles = new[]
                {
                    Permissions.Clerk.ToString()
                };
            }
        }
    }
}