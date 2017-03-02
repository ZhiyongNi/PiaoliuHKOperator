using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiaoliuHKOperator.Models.core;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace PiaoliuHKOperator.Models.engine
{
    class CustomerList
    {
        public List<string> SQLExecuteArray { get; set; }
        public ObservableCollection<Customer> CustomerItemList { get; set; }

        public CustomerList()
        {
            SQLExecuteArray = new List<string>();
            CustomerItemList = new ObservableCollection<Customer>();
        }
        public void findAllCustomerbyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;
            SyncThisbyMethod("findAllCustomerbyFilter");
        }

        private void SyncThisbyMethod(string f_TargetMethod)
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().FullName, f_TargetMethod, JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<CustomerList>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(CustomerList f_CustomerList)
        {
            this.SQLExecuteArray = f_CustomerList.SQLExecuteArray;
            this.CustomerItemList = f_CustomerList.CustomerItemList;
        }
    }
}
