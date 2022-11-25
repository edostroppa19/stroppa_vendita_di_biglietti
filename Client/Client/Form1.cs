using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void avvio_Click(object sender, EventArgs e)
        {
            //SynchronousSocketClient client = new SynchronousSocketClient();
            //client.StartClient();
            panel3.Visible = true;
            avvio.Visible = false;
        }
        private void Procedi_btn_Click(object sender, EventArgs e)
        {
            panel3.Visible=false;
            panel4.Visible = true;
        }
        public void bottoni(Button s)
        {
            numero_btn.Text = s.Text;
            posto_txt.Text = s.Text;
            Procedi_btn.Enabled = true;
            s.BackColor = Color.Yellow;
            s.Enabled = false;
        }

        private void button_A1_Click(object sender, EventArgs e)
        {
            bottoni(button_A1);
        }

        private void button_A2_Click(object sender, EventArgs e)
        {
            bottoni(button_A2);
        }

        private void button_A3_Click(object sender, EventArgs e)
        {
            bottoni(button_A3);
        }

        private void button_A4_Click(object sender, EventArgs e)
        {
            bottoni(button_A4);
        }

        private void button_A5_Click(object sender, EventArgs e)
        {
            bottoni(button_A5);
        }

        private void button_A6_Click(object sender, EventArgs e)
        {
            bottoni(button_A6);

        }

        private void button_A7_Click(object sender, EventArgs e)
        {
            bottoni(button_A7);

        }

        private void button_A8_Click(object sender, EventArgs e)
        {
            bottoni(button_A8);

        }

        private void button_B2_Click(object sender, EventArgs e)
        {
            bottoni(button_B2);

        }

        private void button_B1_Click(object sender, EventArgs e)
        {
            bottoni(button_B1);
        }

        private void button_B3_Click(object sender, EventArgs e)
        {
            bottoni(button_B3);
        }

        private void button_B4_Click(object sender, EventArgs e)
        {
            bottoni(button_B4);
        }

        private void button_H1_Click(object sender, EventArgs e)
        {
            bottoni(button_H1);
        }

        private void button_B5_Click(object sender, EventArgs e)
        {
            bottoni(button_B5);
        }

        private void button_G2_Click(object sender, EventArgs e)
        {
            bottoni(button_G2);
        }

        private void button_B6_Click(object sender, EventArgs e)
        {
            bottoni(button_B6);
        }

        private void button_G1_Click(object sender, EventArgs e)
        {
            bottoni(button_G1);
        }

        private void button_B7_Click(object sender, EventArgs e)
        {
            bottoni(button_B7);
        }

        private void button_F3_Click(object sender, EventArgs e)
        {
            bottoni(button_F3);
        }

        private void button_C1_Click(object sender, EventArgs e)
        {
            bottoni(button_C1);
        }

        private void button_F2_Click(object sender, EventArgs e)
        {
            bottoni(button_F2);
        }

        private void button_C2_Click(object sender, EventArgs e)
        {
            bottoni(button_C2);
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            bottoni(button_F1);
        }

        private void button_C3_Click(object sender, EventArgs e)
        {
            bottoni(button_C3);
        }

        private void button_E4_Click(object sender, EventArgs e)
        {
            bottoni(button_E4);
        }

        private void button_C4_Click(object sender, EventArgs e)
        {
            bottoni(button_C4);
        }

        private void button_E3_Click(object sender, EventArgs e)
        {
            bottoni(button_E3);
        }

        private void button_C5_Click(object sender, EventArgs e)
        {
            bottoni(button_C5);
        }

        private void button_E2_Click(object sender, EventArgs e)
        {
            bottoni(button_E2);
        }

        private void button_C6_Click(object sender, EventArgs e)
        {
            bottoni(button_C6);
        }

        private void button_E1_Click(object sender, EventArgs e)
        {
            bottoni(button_E1);
        }

        private void button_D1_Click(object sender, EventArgs e)
        {
            bottoni(button_D1);
        }

        private void button_D5_Click(object sender, EventArgs e)
        {
            bottoni(button_D5);
        }

        private void button_D2_Click(object sender, EventArgs e)
        {
            bottoni(button_D2);
        }

        private void button_D4_Click(object sender, EventArgs e)
        {
            bottoni(button_D4);
        }

        private void button_D3_Click(object sender, EventArgs e)
        {
            bottoni(button_D3);
        }

        private void btn_ACQUISTA_Click(object senderr, EventArgs ee)
        { // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];
            int count = 0;

            // Connect to a remote device.  
            try
            {
                string data = "";
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                string stringa_da_inviare = posto_txt.Text+"$";

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

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
                    sender.Close();

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
}