using Newtonsoft.Json;
using PiaoliuHKOperator.Models.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class TransitBillList
    {
        public List<string> SQLExecuteArray;
        public List<TransitBill> TransitBillItemList = new List<TransitBill>();
        public void findAllTransitBillbyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;

            SyncClass SyncClass_Instance = new SyncClass("TransitBillList", "findAllTransitBillbyFilter", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<TransitBillList>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(TransitBillList f_TransitBillList)
        {
            this.SQLExecuteArray = f_TransitBillList.SQLExecuteArray;
            this.TransitBillItemList = f_TransitBillList.TransitBillItemList;
        }
    }
}
