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

        private void Server_Load(object sender, EventArgs e)
        {

        }
    }
}