using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.Remoting;

using ChatupNET.Remoting;
using ChatupNET.Model;

namespace ChatupNET.Rooms
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    public delegate void ExitHandler(Room roomInformation);

    /// <summary>
    /// 
    /// </summary>
    public class GroupRoom : AbstractRoom
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="remoteHost"></param>
        public GroupRoom(Room roomInformation, string remoteHost) : base()
        {
            mInstance = roomInformation;
            mIntermediate = new RoomIntermediate();
            mIntermediate.OnJoin += UserJoined;
            mIntermediate.OnLeave += UserLeft;
            mIntermediate.OnMessage += AppendMessage;
            roomInterface = (RoomInterface)RemotingServices.Connect(typeof(RoomInterface), remoteHost);
            roomInterface.OnJoin += mIntermediate.JoinRoom;
            roomInterface.OnLeave += mIntermediate.LeaveRoom;
            roomInterface.OnSend += mIntermediate.SendMessage;

            var userList = roomInterface.List();

            if (userList.Count > 0)
            {
                foreach (var userEntry in userList)
                {
                    UserJoined(new UserProfile(userEntry.Key, userEntry.Value));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        protected override void UserJoined(UserProfile userProfile)
        {
            base.UserJoined(userProfile);
            mInstance.Count++;
            Text = string.Format("{0} [{1:D}/{2:D}]", mInstance.Name, mInstance.Count, mInstance.Capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        protected override void UserLeft(string userName)
        {
            base.UserLeft(userName);
            mInstance.Count--;
            Text = string.Format("{0} [{1:D}/{2:D}]", mInstance.Name, mInstance.Count, mInstance.Capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        private Room mInstance;

        /// <summary>
        /// 
        /// </summary>
        private RoomInterface roomInterface;

        /// <summary>
        /// 
        /// </summary>
        private RoomIntermediate mIntermediate;

        /// <summary>
        /// 
        /// </summary>
        public event ExitHandler ExitHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnClosing(CancelEventArgs args)
        {
            mIntermediate.OnJoin -= UserJoined;
            mIntermediate.OnLeave -= UserLeft;
            mIntermediate.OnMessage -= AppendMessage;

            if (roomInterface != null)
            {
                var operationResult = roomInterface.Leave(ChatupClient.Instance.Username);

                if (operationResult == RemoteResponse.Success)
                {
                    base.OnClosing(args);
                }
                else
                {
                    args.Cancel = true;
                    ErrorHandler.DisplayError(this, operationResult);
                }
            }
            else
            {
                base.OnClosing(args);
            }
        }

        /// <summary>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void buttonValidate_Click(object sender, EventArgs args)
        {
            AppendMessage(GenerateMessage(), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RoomForm_FormClosing(object sender, FormClosingEventArgs args)
        {
            ExitHandler?.Invoke(mInstance);
        }
    }
}