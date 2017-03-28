using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET
{
    /// <summary>
    /// 
    /// </summary>
    internal class ErrorHandler
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<RemoteResponse, string> ResponseMessages = new Dictionary<RemoteResponse, string>()
        {
            { RemoteResponse.AuthenticationFailed, "We couldn't sign you in, please check your username and password and try again!" },
            { RemoteResponse.SessionExists, "Selected user is currently logged in to this service!" },
            { RemoteResponse.BadRequest, "Please check if the information you entered is complete and try again." },
            { RemoteResponse.PermissionDenied, "You currently don't have sufficient permissions to access this!" }
        };

        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<RemoteResponse, string> ResponseTitles = new Dictionary<RemoteResponse, string>()
        {
            { RemoteResponse.AuthenticationFailed, "Login failed" },
            { RemoteResponse.SessionExists, "Session exists" },
            { RemoteResponse.BadRequest, "Missing parameters" },
            { RemoteResponse.PermissionDenied, "Insufficient permissions" }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentForm"></param>
        public ErrorHandler(Form parentForm)
        {
            _parent = parentForm;
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly Form _parent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public void DisplayException(Exception ex)
        {
            MessageBox.Show(_parent,
                ex.Message,
                ex.Source,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationResult"></param>
        public void DisplayError(RemoteResponse operationResult)
        {
            if (ResponseMessages.ContainsKey(operationResult))
            {
                MessageBox.Show(_parent,
                    ResponseMessages[operationResult],
                    ResponseTitles[operationResult],
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(_parent,
                    operationResult.ToString(),
                    operationResult.ToString(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}