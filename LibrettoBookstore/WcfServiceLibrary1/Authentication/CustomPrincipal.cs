using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Threading;

namespace LibrettoWCF.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomPrincipal : IPrincipal
    {
        private string[] _roles;
        private static SqlConnection _connection;

        public CustomPrincipal(IIdentity ident)
        {
            Identity = ident;
        }

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
        // return all roles
        public string[] Roles
        {
            get
            {
                EnsureRoles();
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
            EnsureRoles();
            return _roles.Any(rl => rl == role);
        }

        // read Role of user from database
        protected virtual void EnsureRoles()
        {
            _roles = IsAdmin(Identity.Name) ? new[] { "Administrator" } : new[] { "User" };
            Console.WriteLine("User: {0} Role: {1}", Identity.Name, _roles[0]);
        }

        private static bool IsAdmin(string email)
        {
            if (_connection == null)
            {
                (_connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString)).Open();
            }

            var sqlCommand = new SqlCommand("SELECT id FROM Administrators WHERE email = @email", _connection);

            sqlCommand.Parameters.AddWithValue("@email", email);

            using (var myReader = sqlCommand.ExecuteReader())
            {
                return myReader.Read();
            }
        }
    }
}