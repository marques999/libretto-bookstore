using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace LibrettoWCF.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountValidator : UserNamePasswordValidator
    {
        /// <summary>
        /// 
        /// </summary>
        private static SqlConnection _connection;

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

            if (userEmail == "register")
            {
                return;
            }

            var computedBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(System.Text.Encoding.ASCII.GetBytes(userPassword));
            var computedHash = System.Text.Encoding.ASCII.GetString(computedBytes);
            var connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            if (_connection == null)
            {
                (_connection = new SqlConnection(connectionString)).Open();
            }

            var sqlCommand = new SqlCommand("SELECT password FROM Clients WHERE email = @email", _connection);

            sqlCommand.Parameters.AddWithValue("@email", userEmail);

            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                if (sqlReader.Read())
                {
                    var actualHash = sqlReader.GetString(0);

                    if (computedHash.Equals(actualHash))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Credentials ({0}, {1}) accepted.", userEmail, userPassword);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Credentials ({0}, {1}) not accepted.", userEmail, userPassword);
                        Console.ForegroundColor = ConsoleColor.White;
                        throw new FaultException("Unknown username or password.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Credentials ({0}, {1}) not accepted.", userEmail, userPassword);
                    Console.ForegroundColor = ConsoleColor.White;
                    throw new FaultException("Unknown username or password.");
                }
            }
        }
    }
}