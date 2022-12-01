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
        //Server.Server form = o as Server.Server;
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
            Socket handler;

            while (true)
            {
                handler = listener.Accept();
                gestioneClient gestore = new gestioneClient(handler);
                Thread tc = new Thread(new ParameterizedThreadStart(gestore.gclient));
                tc.Start(o);
            }
        }
        catch (SocketException se)
        {
            Console.WriteLine(se.ToString());
        }
    }

    
       
}

public class gestioneClient
{
    Socket handler;

    public gestioneClient(Socket ServerHandler)
    {
        handler = ServerHandler;
    }
    public void gclient(object Form)
    {
        Server.Server form = Form as Server.Server;
        string data = "";
        byte[] bytes = new byte[1024];
        while (data != "-X-")
        {

            Debug.WriteLine("Waiting for a connection...");


            while (data.IndexOf("$") == -1)
            {
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
            }
            byte[] msg;
            if (data != "OCCUPATI$")
            {
                string[] info = data.Split();
                Debug.WriteLine(data);
                data = data.Replace('$', ' ');
                if (form.Ospiti.IsHandleCreated)
                    form.Ospiti.Invoke(new Action(() => form.Ospiti.Items.Add(data)));
                msg = Encoding.ASCII.GetBytes(data);
            }
            else
            {
                string postiOccupati = "";
                if (form.Ospiti.IsHandleCreated)
                {
                    form.Ospiti.Invoke(new Action(() =>
                    {
                        if (form.Ospiti.Items.Count > 0)
                            for (int i = 0; i < form.Ospiti.Items.Count; i++)
                                postiOccupati += Convert.ToString(form.Ospiti.Items[i]).Split("|")[0] + "|";
                        else 
                            postiOccupati = "Vuoto";
                        postiOccupati += "$";
                    }));
                }
                msg = Encoding.ASCII.GetBytes(postiOccupati);
                handler.Send(msg);
            }
            data = "";
        }
        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();

    }
}
