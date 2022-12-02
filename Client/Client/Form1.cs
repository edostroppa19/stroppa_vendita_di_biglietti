using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace Client
{
    public partial class Form1 : Form
    {
        private Socket Clsender;
        private TextBox p;
        private persona persona;
        private List<Button> bottoniLista;
        public TextBox pst { set { p = value; }get { return p; } }
        public Form1()
        {
            InitializeComponent();
            IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);
            Clsender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Clsender.Connect(remoteEP);
            
        }
        private void avvio_Click(object sender, EventArgs e)
        {
            
            try
            {
                panel3.Visible = true;
                avvio.Visible = false;
                string msg = "OCCUPATI$";
                byte[] bytes = Encoding.UTF8.GetBytes(msg);
                Clsender.Send(bytes);
                string data = "";
                byte[] res = new byte[1024];
                while (data.IndexOf("$") == -1)
                {
                    int bytesRec = Clsender.Receive(res);
                    data += Encoding.ASCII.GetString(res, 0, bytesRec);
                }

                data = data.Substring(0, data.IndexOf("$"));
                string[] postiOccupati = data.Split("|");

                if (postiOccupati.Length > 0 && postiOccupati[0] != "Vuoto")
                {
                    foreach (Control c in Controls)
                    {
                        if (c.GetType() == typeof(Button))
                            foreach (string bottone in postiOccupati)
                            {
                                Control[] botton = this.Controls.Find("button_" + bottone, true);
                                if (botton != null && botton.Length>0)
                                {
                                    botton[0].BackColor = Color.Red;
                                    botton[0].Enabled = false;
                                }
                            }
                    }

                }
            } catch(Exception ) {
                Debug.WriteLine("");
            }
            
            


        }
        public void convalida_acquista()
        {
            if (textBox_cognome.Text != "" && textBox_nome.Text != "" && lista_comuni.Text != "")
            {
                btn_ACQUISTA.Enabled = true;
            }

        }
        public void solo_caratteri_nelle_textbox(TextBox x)
        {
            
        }
        public void passaggio_textbox(string cognome,string nome, string luogo, string data_di_nascita)
        {
             persona = new persona();
            persona.setPersona(nome,cognome,luogo,data_di_nascita);

        }
        public void bottoni(Button s)
        {
            posto_txt.Text = s.Text;
            panel3.Visible = false;
            panel4.Visible = true;
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
        {
            passaggio_textbox(textBox_nome.Text, textBox_cognome.Text, data_di_nascita.Text, lista_comuni.Text);
            string info = persona.getnome() + " " + persona.getcognome() + " " + 
                    persona.getluogo() + " " + persona.getdata_di_nascita();
            SynchronousSocketClient client = new SynchronousSocketClient();
                client.InviadatiClient(ref Clsender,posto_txt,info);
        }
     
        

        private void textBox_cognome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox_nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string line;
            StreamReader file = new StreamReader("comuni.txt");
            line = file.ReadLine();
            while (line != null)
            {
                lista_comuni.Items.Add(line);
                line = file.ReadLine();
            }
            file.Close();
            lista_comuni.Sorted = true;
        }

        private void textBox_cognome_TextChanged(object sender, EventArgs e)
        {
            convalida_acquista();
        }

        private void textBox_nome_TextChanged(object sender, EventArgs e)
        {
            convalida_acquista();
        }
    }
}