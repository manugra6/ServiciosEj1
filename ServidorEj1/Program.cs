﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServidorEj1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Server server = new Server();
            server.conexionServer();
        }
    }
}
