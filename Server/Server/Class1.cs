﻿using Server;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
                string[] info = data.Split();
                Debug.WriteLine(data);
                data = data.Replace('$', ' ');
                MessageBox.Show(data);
                if (form.Ospiti.IsHandleCreated)
                form.Ospiti.Invoke(new Action(() => form.Ospiti.Items.Add(data)));
                // Echo the data back to the client.  
                byte[] msg = Encoding.ASCII.GetBytes(data);

                handler.Send(msg);
                // }
                handler.Shutdown(SocketShutdown.Both);
              //  handler.Close();
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