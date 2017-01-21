using PiaoliuHKOperator.Models.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator
{
    class Global
    {
        public static TcpClient OperatorClientSocket;
        public static String OperatorServer_Host = "127.0.0.1";
        //public static String OperatorServer_Host = "192.168.31.249";
        public static Int16 OperatorServer_Port = 20000;
        public static char SocketDelimiter = '\n';
        public static char SyncDelimiter = '|';

        public static Admin myAdmin;
    }
}
