using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiciosEj1
{
    public partial class Form1 : Form  //Titulo e icono(arreglado), comprobación de puerto e IP, uso de sender
    {
        string ipServer="127.0.0.1";
        int puerto= 31416;
        string msg = "";
        string userMsg;
        public Form1()
        { 
            InitializeComponent();

        }

        public bool ipValida(string ip) 
        {
            IPAddress ipParse;
            if (IPAddress.TryParse(ip,out ipParse))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public void conexionCliente(string mens) 
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipServer), puerto);
            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ie);
                Console.WriteLine("Conexión exitosa al servidor.");
            }
            catch (SocketException ex)
            {
                lblResul.Text = ex.Message;
                return;
            }
            catch(FormatException a)
            {
                lblResul.Text = a.Message;
            }
            using (NetworkStream ns = new NetworkStream(server))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {

                    userMsg = mens;
                    sw.WriteLine(userMsg);
                    sw.Flush();

                    msg = sr.ReadLine();
                    lblResul.Text = msg;
                }

        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text=="close")
            {
                conexionCliente(btnClose.Text + " " + txtContra.Text);
            }
            else
            {
                conexionCliente(((Button)sender).Text);
            }
            
            
        }

        //private void btnDate_Click(object sender, EventArgs e)
        //{
        //    conexionCliente(btnDate.Text);
        //}

        //private void btnAll_Click(object sender, EventArgs e)
        //{
        //    conexionCliente(btnAll.Text);
        //}

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    conexionCliente(btnClose.Text+" "+txtContra.Text);
        //}

        private void btnCambio_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            DialogResult res;
            res = f2.ShowDialog();

            if (res==DialogResult.OK)
            {
                try 
                {
                    
                    this.ipServer = f2.txtIP.Text;
                    this.puerto = int.Parse(f2.txtPuerto.Text);
                    if (!ipValida(ipServer))
                    {
                        throw new FormatException("IP con formato incorrecto");
                    }
                    if (puerto<=0||puerto>=65535)
                    {
                        puerto = 31416;
                        throw new FormatException("Puerto fuera de rango");
                       
                    }
                } 
                catch (Exception exc) when (exc is OverflowException||exc is FormatException)
                {
                    lblResul.Text ="Error: "+exc.Message;
                }
                
            }

        }
    }
}
