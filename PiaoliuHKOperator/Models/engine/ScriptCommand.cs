using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class ScriptCommand
    {
        public List<string> ResultReturnList { get; set; }

        public ScriptCommand()
        {
            ResultReturnList = new List<string>();
        }

        public void IDRepeatChecks()
        {
            SyncThisbyMethod("IDRepeatChecks");
        }

        public void INSYSPackageRelatedTransitBillCheck()
        {
            SyncThisbyMethod("INSYSPackageRelatedTransitBillCheck");
        }

        public void SIGNEDPackageRelatedTransitBillCheck()
        {
            SyncThisbyMethod("SIGNEDPackageRelatedTransitBillCheck");
        }

        public void PendingtoCheckoutTransitBill()
        {
            SyncThisbyMethod("PendingtoCheckoutTransitBill");
        }

        private void SyncThisbyMethod(string f_TargetMethod)
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().FullName, f_TargetMethod, JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<ScriptCommand>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(ScriptCommand f_ScriptCommand)
        {
            this.ResultReturnList = f_ScriptCommand.ResultReturnList;
        }
    }
}
