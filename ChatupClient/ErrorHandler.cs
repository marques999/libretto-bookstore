﻿using ChatupNET.Model;

using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatupNET
{
    class ErrorHandler
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<RemoteResponse, string> responseMessages = new Dictionary<RemoteResponse, string>()
        {
            { RemoteResponse.AuthenticationFailed, Properties.Resources.LoginError },
            { RemoteResponse.SessionExists, "Selected user is currently logged in to this service!" },
            { RemoteResponse.BadRequest, "Please check if the information you entered is complete and try again." },
            { RemoteResponse.PermissionDenied, "You currently don't have sufficient permissions to access this!" }
        };

        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<RemoteResponse, string> responseTitles = new Dictionary<RemoteResponse, string>()
        {
            { RemoteResponse.AuthenticationFailed, Properties.Resources.LoginErrorTitle },
            { RemoteResponse.SessionExists, "Session exists" },
            { RemoteResponse.BadRequest, "Missing parameters" },
            { RemoteResponse.PermissionDenied, "Insufficient permissions" }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="operationResult"></param>
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