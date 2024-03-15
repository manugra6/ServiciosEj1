using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServidorEj1
{
    internal class Server
    {
        private static Socket servidorSocket;
        static string ruta = "C:\\Users\\ManuGra\\Asignaturas\\contra.txt";
        static string password;
        public void conexionServer()
        {
            int port = 130;
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);
            servidorSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            servidorSocket.Bind(ie);
            servidorSocket.Listen(10);
            Console.WriteLine("Conectado");
            while (true)
            {
                try
                {
                    Socket client = servidorSocket.Accept();
                    Thread hilo = new Thread(hiloCliente);
                    hilo.Start(client);
                }
                catch (SocketException e ) 
                {
                    break;
                }
               
            }

        }

        static void hiloCliente(object socket) 
        {
            string respuesta;
            string mensaje;
            Socket sClient = (Socket)socket;
            IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
            Console.WriteLine("Cliente conectado:{0} at {1}",ieClient.Address,ieClient.Port);

            using (NetworkStream ns = new NetworkStream(sClient))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns)) 
            {
                string wlcome = "BIENVENIDOOOOOOOOO (ayuda soy un duende encerrado en este ordenador)";
                sw.WriteLine(wlcome);
                sw.Flush();
                mensaje=sr.ReadLine(); 
                respuesta = ProcessCommand(mensaje);
                sw.Flush();
                try
                {
                    if (mensaje.StartsWith("close"))
                    {
                        if (mensaje.Equals("close " + contra()))
                        {
                            sw.WriteLine("Cerrando servidor");
                            sw.Flush();
                            servidorSocket.Close();
                        }
                        else
                        {
                            sw.WriteLine("Contraseña incorrecta");
                            sw.Flush();
                        }
                    }
                    else
                    {
                        sw.WriteLine(respuesta);
                        sw.Flush();
                    }

                }
                catch (IOException e) 
                {
                
                }

            }
            Console.WriteLine("Cerrando conexion...");
            sClient.Close();
        }

        static string ProcessCommand(string command)
        {
            switch (command)
            {
                case "time":
                    return $"Hora: {DateTime.Now:HH:mm:ss}\n";
                case "date":
                    return $"Fecha: {DateTime.Now:dd-MM-yyyy}\n";
                case "all":
                    return $"Fecha y Hora: {DateTime.Now:dd-MM-yyyy HH:mm:ss}\n";
                default:
                    return "Error: Comando no valido.\n";
            }
        }

        static string contra()
        {
            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    password = sr.ReadLine();
                }
                return password;
            }
            catch (FileNotFoundException) 
            {
                Console.WriteLine("Error");
                return password = "";
            }
           }
    }
}
