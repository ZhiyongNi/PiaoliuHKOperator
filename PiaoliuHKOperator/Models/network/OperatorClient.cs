using PiaoliuHKOperator.Models.engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.network
{
    static class OperatorSocket
    {

        public static void connectSocketServer()
        {
            //await Task.Run(() => { });
            Global.OperatorClientSocket = new TcpClient();
            Global.OperatorClientSocket.Client.Connect(IPAddress.Parse(Global.OperatorServer_Host), Global.OperatorServer_Port);

        }

        public static string DialoguebySocket(string SendString)
        {
            //await Task.Run(() => { });
            char SocketDelimiter = Global.SocketDelimiter;
            TcpClient ClientSocket_Instance = Global.OperatorClientSocket;

            ClientSocket_Instance.SendTimeout = 2000;
            NetworkStream NS = ClientSocket_Instance.GetStream();

            StringBuilder MessageStringBuilder = new StringBuilder();
            MessageStringBuilder.Append(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(SendString)));
            MessageStringBuilder.Append(SocketDelimiter);
            byte[] SendBytes = System.Text.Encoding.UTF8.GetBytes(MessageStringBuilder.ToString());

            NS.Write(SendBytes, 0, SendBytes.Length);
            NS.Flush();

            //ClientSocket_Instance.ReceiveTimeout = 3000;
            MemoryStream StreamBuffer = new MemoryStream();
            byte[] MessageTempData = new byte[1024];
            int i = 0;
            while ((i = NS.Read(MessageTempData, 0, MessageTempData.Length)) != -1)
            {

                if ((System.Text.Encoding.UTF8.GetString(MessageTempData, 0, i)).Contains(SocketDelimiter))
                {
                    StreamBuffer.Write(MessageTempData, 0, i - 1);
                    break;
                }
                else
                {
                    StreamBuffer.Write(MessageTempData, 0, i);
                }
            }

            //NS.Dispose();
            string ReturnString = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(System.Text.Encoding.UTF8.GetString(StreamBuffer.ToArray())));
            return ReturnString;
        }
    }


}
