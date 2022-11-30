using Server;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

public class SynchronousSocketListener
{

    // Incoming data from the client.  
    public string data = null;


    public SynchronousSocketListener(ref string data)
    {
        this.data = data;
    }

    public void StartListening(object o)
    {
        Server.Server form = o as Server.Server;
        byte[] bytes = new Byte[1024];
        IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);  
        Socket listener = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

        Console.WriteLine("Timeout : {0}", listener.ReceiveTimeout);
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);
            while (true)
            {

                Debug.WriteLine("Waiting for a connection...");
                Socket handler = listener.Accept();
                data = "";
                while (data.IndexOf("$") == -1)
                {
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                }
                byte[] msg;
                    string[] info = data.Split();
                    Debug.WriteLine(data);
                    data = data.Replace('$', ' ');
                    MessageBox.Show(data);
                    if (form.Ospiti.IsHandleCreated)
                        form.Ospiti.Invoke(new Action(() => form.Ospiti.Items.Add(data))); 
                    msg = Encoding.ASCII.GetBytes(data);
        
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
}