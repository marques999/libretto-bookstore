using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;

using LibrettoWCF.Database;
using LibrettoWCF.Tools;

namespace LibrettoWCF.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class ClerkValidator : UserNamePasswordValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userPassword"></param>
        public override void Validate(string userEmail, string userPassword)
        {
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userPassword))
            {
                throw new FaultException("Username or password not specified.");
            }

            var clerkInformation = LibrettoDatabase.ClerkIntegration.Lookup(userEmail);

            if (string.IsNullOrEmpty(clerkInformation?.Password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"Credentials ({0}, {1}) not accepted.", userEmail, userPassword);
                Console.ForegroundColor = ConsoleColor.White;
                throw new FaultException("Unknown username or password.");
            }

            if (PasswordUtilities.Verify(userPassword, clerkInformation.Password))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"Credentials ({0}, {1}) accepted.", userEmail, userPassword);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"Credentials ({0}, {1}) not accepted.", userEmail, userPassword);
                Console.ForegroundColor = ConsoleColor.White;
                throw new FaultException("Unknown username or password.");
            }
        }
    }
}