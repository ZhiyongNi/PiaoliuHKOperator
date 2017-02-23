using Newtonsoft.Json;
using PiaoliuHKOperator.Models.core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class TransitBillList
    {
        public List<string> SQLExecuteArray;
        public ObservableCollection<TransitBill> TransitBillItemList = new ObservableCollection<TransitBill>();
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
        public void findSIGNEDTransitBillbyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;

            SyncClass SyncClass_Instance = new SyncClass("TransitBillList", "findSIGNEDTransitBillbyFilter", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<TransitBillList>(SyncClass_Instance.SyncJsonString));
            }
        }

        public void findINSYSTransitBillbyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;

            SyncClass SyncClass_Instance = new SyncClass("TransitBillList", "findINSYSTransitBillbyFilter", JsonConvert.SerializeObject(this));
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
