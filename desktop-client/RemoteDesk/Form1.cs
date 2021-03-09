using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesk
{
    public partial class Form1 : Form
    {

        private bool b = true;
        private Utils utils = new Utils();
        private string mIp, mPort;
        private bool stopWorker = true;
        private Socket clientSocket,listener;
        private Robot robot = new Robot();

        public Form1()
        {
            InitializeComponent();
            pictureBtn.Image = Properties.Resources.start;
            this.Icon = Properties.Resources.Logo;
            initNetwork();
            logBox.Multiline = true;
        }

        private void min_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBtn_Click(object sender, EventArgs e)
        {
            if (b)
            {
                pictureBtn.Image = Properties.Resources.stop;
                b = false;
                stopWorker = true;
                NetworkWorker.WorkerSupportsCancellation = true;
                if (NetworkWorker.IsBusy)
                {
                    try
                    {
                        stopWorker = false;
                        listener.Close();
                        listener = null;
                    }
                    catch (Exception e3)
                    {

                    }
                }
                try
                {
                    NetworkWorker.RunWorkerAsync();
                    log("Creating QR Code...");
                    utils.generateQr("ANSOFT_CODE;" + mIp + ";" + mPort, qrBox);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Connection Error!!\nRestart Application!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                pictureBtn.Image = Properties.Resources.start;
                utils.generateQr(".", qrBox);
                b = true;
                log("Closing service at: " + "http://" + mIp + ":" + mPort);
                try 
                {
                        stopWorker = false;
                        listener.Close();
                        listener = null;
                        log("Connection Closed Successfully!");
                }catch(Exception e3) 
                {
                    log("Connection Closing Error!");
                }
            }
        }

        private void networkError()
        {
            MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
            DialogResult result = MessageBox.Show("No connected network found!", "Error", buttons, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Cancel)
            {
                Task.Delay(2000).ContinueWith(t => Application.Exit());
            }
            else if (result == DialogResult.Retry)
            {
                initNetwork();
            }
        }

        private void initNetwork()
        {
            log("Initializing Network...");
            string ip = utils.GetLocalIPAddress();
            if (ip.Length > 0)
            {
                string port = utils.getRandomPort(ip);
                ip_label.Text = ip;
                port_label.Text = port;
                mIp = ip;
                mPort = port;
                log("Network Address Created:- http://"+ip+":"+port);
                utils.generateQr(".", qrBox);
                log("Ready To Go!");
            }
            else
            {
                log("Network Error!");
                networkError();
            }
        }

        private void carbonFiberLabel3_Click(object sender, EventArgs e)
        {

        }

        private void NetworkWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            log("Opening service at: " + "http://" + mIp + ":" + mPort);
            /*
            try
            {
                //IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                //IPAddress ipAddr = ipHost.AddressList[0];
                IPAddress ipAddr = IPAddress.Parse("192.168.43.1");
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 6060);
                Socket s_sender = new Socket(ipAddr.AddressFamily,
                   SocketType.Stream, ProtocolType.Tcp);

                try {

                    // Connect Socket to the remote  
                    // endpoint using method Connect()
                    s_sender.Connect(localEndPoint);

                    // We print EndPoint information  
                    // that we are connected 
                    Console.WriteLine("Socket connected to -> {0} ",
                                  s_sender.RemoteEndPoint.ToString());

                    // Creation of messagge that 
                    // we will send to Server 

                    System.Threading.Thread.Sleep(2000);

                    byte[] messageSent = Encoding.ASCII.GetBytes("Test Client Message");
                    int byteSent = s_sender.Send(messageSent);

                    // Data buffer 
                    byte[] messageReceived = new byte[1024];

                    // We receive the messagge using  
                    // the method Receive(). This  
                    // method returns number of bytes 
                    // received, that we'll use to  
                    // convert them to string 
                    int byteRecv = s_sender.Receive(messageReceived);
                    Console.WriteLine("Message from Server -> {0}",
                          Encoding.ASCII.GetString(messageReceived,
                                                     0, byteRecv));

                    // Close Socket using  
                    // the method Close() 
                    // sender.Shutdown(SocketShutdown.Both);
                    // sender.Close();
                }catch(Exception e3)
                {
                    Console.WriteLine("Error1: {0}",e3.ToString());
                }
            }
            catch(Exception e2)
            {
                Console.WriteLine("Error2: {0}", e2.ToString());
            }
            */
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[1];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Convert.ToInt32(mPort));
                listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);
                    while (stopWorker)
                    {
                        log("Waiting for connection ... ");
                        clientSocket = listener.Accept();
                        byte[] bytes = new Byte[1024];
                        string data = null;
                        while (stopWorker)
                        {
                            int numByte = clientSocket.Receive(bytes);
                            if (numByte == 0)
                            {
                                break;
                            }
                            data = Encoding.ASCII.GetString(bytes, 0, numByte);
                            data = utils.CleanASCII(data);
                            if (data.StartsWith("ANSOFT"))
                            {
                                log(data.Split(':')[1]);
                            }else
                            {
                                robot.evaluateCommand(data);
                            }
                        }
                    }
                }
                catch (Exception e2)
                {
                    //log("Error: " + e2.Message);
                }
            }
            catch (Exception e1)
            {
                //log("Error: " + e1.Message);
            }
        }

        public void log(string log)
        {
            logBox.Invoke(new Action(() => logBox.Text = logBox.Text + "-> " + log + Environment.NewLine));
            logBox.Invoke(new Action(() => logBox.SelectionStart = logBox.Text.Length));
            logBox.Invoke(new Action(() => logBox.ScrollToCaret()));
        }
    }
}
