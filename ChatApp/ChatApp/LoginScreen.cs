using ChatApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class ChatWindow : Form
{

    IUserSingleton userServer;
    AlterEventUserRepeater evRepeater;
    
    public ChatWindow()
    {
        RemotingConfiguration.Configure("ChatApp.exe.config", false);
        InitializeComponent();

        userServer  = (IUserSingleton)RemoteNew.New(typeof(IUserSingleton));
        evRepeater  = new AlterEventUserRepeater();

        evRepeater.alterEvent += new AlterDelegateUser(DoAlterations);
        userServer.alterEvent += new AlterDelegateUser(evRepeater.Repeater);
           
    }

    public void DoAlterations(UserOperation op, User usr)
    {
        /*LVAddDelegate lvAdd;
        ChCommDelegate chComm;*/

        /*switch (op)
        {
            case UserOperation.New:
                lvAdd = new LVAddDelegate(itemListView.Items.Add);
                ListViewItem lvItem = new ListViewItem(new string[] { item.Type.ToString(), item.Name, item.Comment });
                BeginInvoke(lvAdd, new object[] { lvItem });
                break;
        }*/
    }

    private void ChatWindow_Load(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void register_Click(object sender, EventArgs e)
    {
        userServer.AddUser(new User(2, userServer.GetUsers().Count, usernameBox.Text, "Something Here", passwordBox.Text));
        /*var menu = new Main();
        menu.Show();*/
        //Hide();
    }

    private void login_Click(object sender, EventArgs e)
    {
        if (userServer.LoginUser(new User(0, 0, usernameBox.Text, "", passwordBox.Text)))
        {
            var menu = new Main(new User(0,0,usernameBox.Text,"",""));
            menu.Show();
            Hide();
        }else
        {
            this.Hide();
            var dialog = new ErrorDialog();
            if(dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Show();
            }else
            {
                this.Show();
            }

            dialog.Dispose();
        }
        
    }
}

class RemoteNew
{
    private static Hashtable types = null;

    private static void InitTypeTable()
    {
        types = new Hashtable();
        foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            types.Add(entry.ObjectType, entry);
    }

    public static object New(Type type)
    {
        if (types == null)
            InitTypeTable();
        WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)types[type];
        if (entry == null)
            throw new RemotingException("Type not found!");
        return RemotingServices.Connect(type, entry.ObjectUrl);
    }
}

