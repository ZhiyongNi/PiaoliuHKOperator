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
        //public static String OperatorServer_Host = "127.0.0.1";
        public static String OperatorServer_Host = "192.168.31.65";
        public static Int16 OperatorServer_Port = 20000;
        public static char SocketDelimiter = '\n';
        public static char SyncDelimiter = '|';

        public static Admin myAdmin;

        public static class PiaoliuHK_Configs_GlobalConstant_TransitBillStatus
        {

            static int Signed = 1;
            static String SignedChinese = "已签收";
            static int inShip = 2;
            static String inShipChinese = "在途";
            static int Checkout = 3;
            static String CheckoutChinese = "需出库";
            static int Pending = 4;
            static String PendingChinese = "待配齐";
        }
    }
}
