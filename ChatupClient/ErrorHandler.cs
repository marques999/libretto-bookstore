using ChatupNET.Model;

using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatupNET
{
    class ErrorHandler
    {
        private static Dictionary<RemoteResponse, string> responseMessages = new Dictionary<RemoteResponse, string>()
        {
            { RemoteResponse.AuthenticationFailed, Properties.Resources.LoginError },
            { RemoteResponse.SessionExists, "Selected user is currently logged in to this service!" },
            { RemoteResponse.MissingParameters, "Please check if the information you entered is complete and try again." },
            { RemoteResponse.InsufficientPermissions, "You currently don't have sufficient permissions to access this!" }
        };

        private static Dictionary<RemoteResponse, string> responseTitles = new Dictionary<RemoteResponse, string>()
        {
            { RemoteResponse.AuthenticationFailed, Properties.Resources.LoginErrorTitle },
            { RemoteResponse.SessionExists, "Session exists" },
            { RemoteResponse.MissingParameters, "Missing parameters" },
            { RemoteResponse.InsufficientPermissions, "Insufficient permissions" }
        };

        public static void DisplayError(Form parentForm, RemoteResponse operationResult)
        {
            MessageBox.Show(parentForm,
                responseMessages[operationResult],
                responseTitles[operationResult],
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}
