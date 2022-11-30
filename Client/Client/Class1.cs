using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SynchronousSocketClient
{

    public void InviadatiClient(ref Socket sender,TextBox posto_txt)
    {
        // Data buffer for incoming data.  
        byte[] bytes = new byte[1024];
        int count = 0;

        // Connect to a remote device.  
        try
        {
            string data = "";
            

            // Create a TCP/IP  socket.  
            
            string stringa_da_inviare = posto_txt.Text + "$";

            // Connect the socket to the remote endpoint. Catch any errors.  
            try
            {
                Console.WriteLine("Socket connected to {0}",
                    sender.RemoteEndPoint.ToString());
                while (data != "Quit$")
                {

                    byte[] msg = Encoding.ASCII.GetBytes(stringa_da_inviare);              //("This is a test<EOF>");

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);
                    data = "";
                    // Receive the response from the remote device.  
                    while (data.IndexOf("$") == -1)
                    {
                        int bytesRec = sender.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    }
                    Console.WriteLine("Messaggio ricevuto: " + data);
                }
                // Release the socket.
                sender.Shutdown(SocketShutdown.Both);
                //     sender.Close();

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}