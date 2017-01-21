using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Net.Sockets;
using System.Net;
using PiaoliuHKOperator.Models.network;

namespace PiaoliuHKOperator.Models.engine
{
    class SyncClass
    {
        public long SyncSerial { get; set; }
        public string SyncClassName { get; set; }
        public string SyncCommand { get; set; }
        public string SyncJsonString { get; set; }
        public Boolean SyncSucceed = false;

        public SyncClass(string f_SyncClassName, string f_SyncCommand, string f_SyncJsonString)
        {
            long SyncClass_Serial = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);

            this.SyncSerial = SyncClass_Serial;
            this.SyncClassName = f_SyncClassName;
            this.SyncCommand = f_SyncCommand;
            this.SyncJsonString = f_SyncJsonString;
            this.SyncSucceed = false;
        }
        public string getSyncSendString()
        {
            StringBuilder MessageStringBuilder = new StringBuilder();
            MessageStringBuilder.Append(this.SyncSerial);
            MessageStringBuilder.Append(Global.SyncDelimiter);
            MessageStringBuilder.Append(this.SyncClassName);
            MessageStringBuilder.Append(Global.SyncDelimiter);
            MessageStringBuilder.Append(this.SyncCommand);
            MessageStringBuilder.Append(Global.SyncDelimiter);
            MessageStringBuilder.Append(this.SyncJsonString);

            //return System.Text.Encoding.UTF8.GetBytes(MessageStringBuilder.ToString());
            return MessageStringBuilder.ToString();
        }

        public void SyncReturn(string f_Return)
        {
            string[] ReturnString = f_Return.Split(Global.SyncDelimiter);
            if (ReturnString[0] == SyncSerial.ToString())
            {
                this.SyncJsonString = ReturnString[1];
                this.SyncSucceed = true;
            }
        }


        public void SyncbySocket()
        {
            string ReturnString = OperatorSocket.DialoguebySocket(this.getSyncSendString());
            SyncReturn(ReturnString);
        }
    }
}
