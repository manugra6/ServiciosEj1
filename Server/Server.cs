using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Configuration;

namespace Server
{
    internal class Server  //Cierre abrupto, directorio absolutos no(arregaldo), puerto ocupado(arreglado), mensaje de que falta pass(arreglado creo), close con varios clientes, IOException(arreglado)
    {
        Socket servidorSocket;
        static string ruta = Environment.GetEnvironmentVariable("HOMEPATH") + "\\Asignaturas\\contra.txt";
        
        static string password;
        int port = 31416;
        bool puertoOcupado=true;

        public void conexionServer()
        {
            
            Console.WriteLine(ruta);
            int puertoAuziliar=1024;
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);
            using (servidorSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) 
            {
                while (puertoOcupado)
                {
                    try
                    {
                        servidorSocket.Bind(ie);
                        servidorSocket.Listen(10);
                        Console.WriteLine("Servidor Iniciado");
                        puertoOcupado = false;
                        while (true)
                        {
                            Socket client = servidorSocket.Accept();
                            Thread hilo = new Thread(hiloCliente);
                            hilo.Start(client);

                        }
                    }
                    catch (SocketException e) when
                    (e.ErrorCode == (int)SocketError.AddressAlreadyInUse)
                    {
                        Console.WriteLine("Puerto en uso");
                        puertoOcupado = true;
                        puertoAuziliar++;
                        port = puertoAuziliar;

                    }
                    catch (SocketException ex) 
                    {
                        
                    }

                }
            
                
            }
        }


        public void hiloCliente(object socket)
        {
            string respuesta;
            string mensaje;
            Socket sClient = (Socket)socket;
            IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
            Console.WriteLine("Cliente conectado:{0} at {1}", ieClient.Address, ieClient.Port);

            using (NetworkStream ns = new NetworkStream(sClient))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                respuesta = "";
                try
                {
                    mensaje = sr.ReadLine();
                    if (mensaje!=null)
                    {
                        if (mensaje.StartsWith("close"))
                        {
                            respuesta = ProcessCommand(mensaje);
                            sw.Flush();

                            if (mensaje == "close " + contra())
                            {
                                servidorSocket.Close();
                            }
                            else
                            if (mensaje == "close")
                            {
                                sw.WriteLine("Contraseña Vacia");
                                sw.Flush();
                            }

                            else
                            {
                                sw.WriteLine("Contraseña incorrecta");
                                sw.Flush();
                            }
                        }
                        else
                        {
                            respuesta = ProcessCommand(mensaje);
                            sw.WriteLine(respuesta);
                            sw.Flush();
                        }
                    }
                    

                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Mensaje fue Null");
                }
                catch (IOException n) 
                {
                    Console.WriteLine("Error de acceso");
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
            }catch (IOException e) 
            {
                Console.WriteLine(e.Message);
                return password = "";
            }
        }
    }
}
