﻿using System;
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
            { RemoteResponse.UserExists, "A person with the same username already exists in the server!" },
            { RemoteResponse.PermissionDenied, "You don't have enough permissions to perform this action!" },
            { RemoteResponse.InvalidPassword, "The room password you entered was recognized as invalid!" },
            { RemoteResponse.ConversationExists, "You're currently participating in this conversation!" },
            { RemoteResponse.SessionExists, "User is currently logged in to this service, please sign out first!" },
            { RemoteResponse.BadRequest, "Please check if the information you entered is complete and try again." },
            { RemoteResponse.AuthenticationFailed, "We couldn't authenticate with the details you provided, please check your username and password and try again!" },
            { RemoteResponse.RoomFull, "The room you are trying to join is currently full, please wait until someone leaves!" },
        };

        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<RemoteResponse, string> ResponseTitles = new Dictionary<RemoteResponse, string>()
        {
            { RemoteResponse.RoomFull, "Room full" },
            { RemoteResponse.NotFound, "Invalid entity" },
            { RemoteResponse.UserExists, "User exists" },
            { RemoteResponse.ConversationExists, "Conversation exists" },
            { RemoteResponse.InvalidPassword, "Wrong password" },
            { RemoteResponse.SessionExists, "Session exists" },
            { RemoteResponse.BadRequest, "Missing parameters" },
            { RemoteResponse.OperationFailed, "Operation failed" },
            { RemoteResponse.AuthenticationFailed, "Login error" },
            { RemoteResponse.PermissionDenied, "Insufficient permissions" },
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
            MessageBox.Show(_parent, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationResult"></param>
        public void DisplayError(RemoteResponse operationResult)
        {
            MessageBox.Show(_parent,
                ResponseMessages.ContainsKey(operationResult)
                    ? ResponseMessages[operationResult]
                    : operationResult.ToString(),
                ResponseTitles.ContainsKey(operationResult)
                    ? ResponseTitles[operationResult]
                    : operationResult.ToString(),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}