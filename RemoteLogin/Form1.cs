using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using RemoteLogin;

namespace RemoteLogin
{
    public partial class Form1 : Form
    {

        public Socket clientSocket;
        /* public UdpClient clientSocket;*/
        public EndPoint epServer;
        byte[] byteData = new byte[1024];
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {


            CheckForIllegalCrossThreadCalls = false;
            IPEndPoint ipeServer = new IPEndPoint(IPAddress.Parse("192.168.112.11"), 33332);
            epServer = (EndPoint)ipeServer;
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            clientSocket.Bind(new IPEndPoint(IPAddress.Any, 33333));

            /*UdpClient client=new UdpClient(33333);
            client.BeginReceive()*/



            SendTo(epServer, "init...");
            byteData = new byte[1024];
            clientSocket.BeginReceiveFrom(byteData,
                0, byteData.Length,
                SocketFlags.None,
                ref epServer,
                new AsyncCallback(OnReceive),
                 null);




        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SendTo(epServer, textBox2.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SendTo(epServer, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //将消息msg发送到指定endPoint
        private void SendTo(EndPoint epSender, String msg)
        {
            Data data = new Data();
            data.Name = Dns.GetHostName();
            data.Message = msg;

            byte[] message = System.Text.Encoding.Default.GetBytes(data.ToString());
            try
            {
                clientSocket.BeginSendTo(message, 0,
                    message.Length, SocketFlags.None,
                    epSender,
                    new AsyncCallback(OnSend),
                    null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //异步发送的回调函数
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int iBytes = clientSocket.EndReceive(ar);
                string message = System.Text.Encoding.Default.GetString(byteData);
                //根据数据类型，处理数据
                txt_Cookie.Text = txt_Cookie.Text + message + "\r\n";

                Hashtable Reqhashtable = new Hashtable();
                message = message.Replace("{", "");
                message = message.Replace("}", "");
                message = message.Replace("\"", "");
                string[] msg = message.Split(',');
                foreach (var m in msg)
                {
                   
                    Reqhashtable.Add(m.Split(':')[0], UEscape(m.Split(':')[1]));
                }
                var url = Reqhashtable["url"];
              

                //继续接受消息
                clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length,
                    SocketFlags.None, ref epServer, new AsyncCallback(OnReceive), epServer);
                //验证请求规则
                if (epServer.ToString() == Reqhashtable["from"].ToString() &&
                    !string.IsNullOrEmpty(Reqhashtable["sourceip"].ToString()) &&
                    !string.IsNullOrEmpty(Reqhashtable["url"].ToString()) &&
                    !string.IsNullOrEmpty(Reqhashtable["flag"].ToString()) &&
                    Reqhashtable["flag"].ToString() == "1"
                    )
                {
                    webBrowser1.Url = new Uri(UEscape(url.ToString()));

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cookie_Click(object sender, EventArgs e)
        {
            /*string cookieStr = GetCookieString(webBrowser1.Url.ToString());*/
            string cookieStr = FullWebBrowserCookie.GetCookieInternal(webBrowser1.Url, false);

            txt_Cookie.Text = cookieStr;
        }
        public string UEscape(string str)
        {

            StringBuilder s = new StringBuilder();

            int c = str.Length;

            int i = 0;

            while (i != c)
            {

                if (Uri.IsHexEncoding(str, i))
                {

                    s.Append(Uri.HexUnescape(str, ref i));

                }

                else
                {

                    s.Append(str[i++]);

                }



            }

            return s.ToString();

        }
    }
}

class Data
{

    public string Name { get; set; }
    public string Message { get; set; }
    public override string ToString()
    {
        return Message;
    }

}