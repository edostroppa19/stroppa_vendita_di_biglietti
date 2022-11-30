using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public partial class Server : Form
    {
        private string data2;
        private ListBox lista;

        public ListBox Ospiti { set { lista = value; } get { return lista; } }
        public Server()
        {
            InitializeComponent();
        }

        private void avvio_btn_Click(object sender, EventArgs e)
        {
            Ospiti = Elenco_ospiti;
            SynchronousSocketListener listener = new SynchronousSocketListener(ref data2);
            Thread t = new Thread(new ParameterizedThreadStart(listener.StartListening));
            t.Start(this);
        }

        // Incoming data from the client.  
        public static string data = null;

        public void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Timeout : {0}", listener.ReceiveTimeout);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {

                    Debug.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();

                    //while (data != "Quit$")
                    //{
                    // An incoming connection needs to be processed.  
                    data = "";
                    while (data.IndexOf("$") == -1)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    }

                    // Show the data on the console. 

                    Debug.WriteLine("Messaggio ricevuto : {0}", data);
                    string[] info = data.Split();
                    MessageBox.Show(data);
                    Elenco_ospiti.Items.Add(data);
                    this.Refresh();
                    // Echo the data back to the client.  
                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    handler.Send(msg);
                    // }
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    data = "";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        private void Server_Load(object sender, EventArgs e)
        {

        }
    }
}