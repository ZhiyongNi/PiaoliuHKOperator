﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class ScriptCommand
    {
        public List<string> ResultReturnList = new List<string>();

        public void IDRepeatChecks()
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().Name, "IDRepeatChecks", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<ScriptCommand>(SyncClass_Instance.SyncJsonString));
            }
        }

        public void INSYSPackageRelatedTransitBillCheck()
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().Name, "INSYSPackageRelatedTransitBillCheck", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<ScriptCommand>(SyncClass_Instance.SyncJsonString));
            }
        }

        public void SIGNEDPackageRelatedTransitBillCheck()
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().Name, "SIGNEDPackageRelatedTransitBillCheck", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<ScriptCommand>(SyncClass_Instance.SyncJsonString));
            }
        }

        public void PendingtoCheckoutTransitBill()
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().Name, "PendingtoCheckoutTransitBill", JsonConvert.SerializeObject(this));
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