using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace ChatClient
{
    [ServiceContract(CallbackContract = typeof(IChatService))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Join(string memberName);
        [OperationContract(IsOneWay = true)]
        void Leave(string memberName);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string memberName, string message);
        [OperationContract(IsOneWay = true)]
        void SendFile(string username, string file, byte[] content);
    }

    public interface IChatChannel : IChatService, IClientChannel
    {

    }

    public partial class Client : Form,IChatService
    {
        private delegate void UserJoined(string name);
        private delegate void UserSendMessage(string name, string message);
        private delegate void UserLeft(string name);
        private delegate void userSendFile(String username,string file,byte[]content);
        
        private static event UserJoined NewJoin;
        private static event UserSendMessage MessageSent;
        private static event UserLeft RemoveUser;
        private static event userSendFile SentFile;

        private string userName;
        private IChatChannel channel;
        private DuplexChannelFactory<IChatChannel>factory=null;
        
        public Client()
        {
            InitializeComponent();
            this.AcceptButton = btnSend;
           
        }
   

        public Client(string username)
        {

            this.userName = Login.username;
       
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
    {
            try
            {
                NewJoin += new UserJoined(ChatClient_NewJoin);
                MessageSent += new UserSendMessage(ChatClient_MessageSent);
                RemoveUser += new UserLeft(ChatClient_RemoveUser);
                SentFile += new userSendFile(Chat_sentFile);
               
                this.userName = Login.username;
                InstanceContext context = new InstanceContext(
                    new Client(Login.username));
                DuplexChannelFactory<IChatChannel>factory = new DuplexChannelFactory<IChatChannel>(context, "ChatEndPoint");
                    
                channel = factory.CreateChannel();
                IOnlineStatus status = channel.GetProperty<IOnlineStatus>();
                status.Offline += new EventHandler(Offline);
                status.Online += new EventHandler(Online);
                channel.Open();
                channel.Join(this.userName);
                grpMessageWindow.Enabled = true;
                grpUserList.Enabled = true;
               
                this.AcceptButton = btnSend;
               
                txtSendMessage.Select();
                txtSendMessage.Focus();

                btnLogin.Enabled=false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        void ChatClient_RemoveUser(string name)
        {
            try
            {
                rtbMessages.AppendText("\r\n");
                rtbMessages.AppendText(name + " left at " + DateTime.Now.ToString());
                Users.Items.Remove(name);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        void ChatClient_MessageSent(string name, string message)
        {
            if (!Users.Items.Contains(name))
            {
                Users.Items.Add(name);
            }
            rtbMessages.AppendText("\r\n");
            rtbMessages.AppendText(name + " says: " + message);
        }

        void Chat_sentFile(string username, string file, byte[] content)
        {
            String path = @"D:\University\Final Project\File\" + file;
            if (!File.Exists(path))
            {
                File.WriteAllBytes(path, content);
            
            }
            MessageBox.Show("File"+file+"Received From"+ username);
        
        }
        void ChatClient_NewJoin(string name)
        {
            rtbMessages.AppendText("\r\n");
            rtbMessages.AppendText(name + " joined at: [" + DateTime.Now.ToString() + "]");            
            Users.Items.Add(name);       
        }

        void Online(object sender, EventArgs e)
        {            
            rtbMessages.AppendText("\r\nOnline: " + this.userName);
        }

        void Offline(object sender, EventArgs e)
        {
            rtbMessages.AppendText("\r\nOffline: " + this.userName);
        }


        public void Join(string memberName)
        {            
            if (NewJoin != null)
            {
                NewJoin(memberName);
            }
        }

        public new void Leave(string memberName)
        {
            if (RemoveUser != null)
            {
                RemoveUser(memberName);
            }
        }

        public void SendMessage(string memberName, string message)
        {
            if (MessageSent != null)
            {
                MessageSent(memberName, message);
            }
            
        }

        public void SendFile(string username, string file, byte[] content)
        {
            
                SentFile(username, file, content);
        }
      
       

        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (channel != null)
                {
                    channel.Leave(this.userName);
                    channel.Close();
                }
                if (factory != null)
                {
                    factory.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void rtbMessages_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpMessageWindow_Enter(object sender, EventArgs e)
        {

        }

        private void ChatClient_Load(object sender, EventArgs e)
        {
             
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            bool check = true;
            if (button1.Text != "Attach File") 
            {
                check = false;
                try
                {
                    FileInfo fileinfo = new FileInfo(button1.Text);
                    byte[] file = File.ReadAllBytes(button1.Text);
                    channel.SendFile(this.userName, fileinfo.Name, file);
                    button1.Text = "Attach File";
                    channel.SendMessage(this.userName, "File Sent");
                }
                catch {
                    MessageBox.Show("Error");
                }
            }
            if (check)
            {
                channel.SendMessage(this.userName, txtSendMessage.Text.Trim());
                
                txtSendMessage.Clear();
                txtSendMessage.Select();
                txtSendMessage.Focus();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;
            fd.ShowDialog();
            button1.Text = fd.FileName;
        }

        
      

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void txtSendMessage_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}