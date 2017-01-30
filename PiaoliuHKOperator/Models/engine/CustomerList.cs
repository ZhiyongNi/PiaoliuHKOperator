using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiaoliuHKOperator.Models.core;
using Newtonsoft.Json;

namespace PiaoliuHKOperator.Models.engine
{
    class CustomerList
    {
        public List<string> SQLExecuteArray;
        public List<Customer> CustomerItemList = new List<Customer>();
        public void findAllCustomerbyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;

            SyncClass SyncClass_Instance = new SyncClass("CustomerList", "findAllCustomerbyFilter", JsonConvert.SerializeObject(this));
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
