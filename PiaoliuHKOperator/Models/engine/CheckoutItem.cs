using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PiaoliuHKOperator.Models.DataCSV.DataToCSVFile;

namespace PiaoliuHKOperator.Models.engine
{
    class CheckoutItem
    {
        public string TransitBillSerialID { get; set; }
        public int TransitBillOwnerID { get; set; }
        public class CustomerInfo
        {
            public string CustomerRealName { get; set; }
            public string CustomerSelfMobile { get; set; }
        }
        public class PackageInfo
        {
            public string PackageSerialID { get; set; }
            public float PackageWeight { get; set; }
        }
        public List<CustomerInfo> CustomerInfo_List { get; set; }

        public int TransitBillRelatedPackageQuantity { get; set; }
        public float TransitBillPrice { get; set; }
        public string TransitBillAddress { get; set; }

        public List<PackageInfo> PackageInfo_List { get; set; }




        public CheckoutItem()
        {
            CustomerInfo_List = new List<CustomerInfo>();
            PackageInfo_List = new List<PackageInfo>();
        }

        public void FillupSelfInfo()
        {
            SyncThisbyMethod("FillupSelfInfo");
        }
        private void SyncThisbyMethod(string f_TargetMethod)
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().FullName, f_TargetMethod, JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<CheckoutItem>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(CheckoutItem f_CheckoutItem)
        {
            this.CustomerInfo_List = f_CheckoutItem.CustomerInfo_List;
            this.PackageInfo_List = f_CheckoutItem.PackageInfo_List;
        }
    }

    class CheckoutItemLite
    {
        public string TransitBillSerialID { get; set; }
        public int TransitBillOwnerID { get; set; }
        public string CustomerRealName { get; set; }
        public string CustomerSelfMobile { get; set; }

        public float PackageWeight_1 { get; set; }
        public float PackageWeight_2 { get; set; }
        public float PackageWeight_3 { get; set; }
        public float PackageWeight_4 { get; set; }
        public float PackageWeight_5 { get; set; }
        public float PackageWeight_6 { get; set; }
        public float PackageWeight_7 { get; set; }
        public float PackageWeight_8 { get; set; }
        public string PackageSerialID_1 { get; set; }
        public string PackageSerialID_2 { get; set; }
        public string PackageSerialID_3 { get; set; }
        public string PackageSerialID_4 { get; set; }
        public string PackageSerialID_5 { get; set; }
        public string PackageSerialID_6 { get; set; }
        public string PackageSerialID_7 { get; set; }
        public string PackageSerialID_8 { get; set; }

        public int TransitBillRelatedPackageQuantity { get; set; }
        public float TransitBillPrice { get; set; }
        public string TransitBillAddress { get; set; }
    }
}
