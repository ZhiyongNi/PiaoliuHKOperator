using Newtonsoft.Json;
using PiaoliuHKOperator.Models.core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine.DataCSV
{
    class TransitBillCheckoutCSVItem
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
        public List<PackageInfo> PackageInfo_List { get; set; }

        public int TransitBillRelatedPackageQuantity { get; set; }
        public float TransitBillPrice { get; set; }
        public string TransitBillAddress { get; set; }

        public TransitBillCheckoutCSVItem()
        { }
        public TransitBillCheckoutCSVItem(TransitBill f_TransitBill)
        {
            this.TransitBillSerialID = f_TransitBill.TransitBillSerialID;
            this.TransitBillOwnerID = f_TransitBill.TransitBillOwnerID;
            this.TransitBillRelatedPackageQuantity = f_TransitBill.TransitBillRelatedPackageQuantity;
            this.TransitBillPrice = f_TransitBill.TransitBillPrice;
            this.TransitBillAddress = f_TransitBill.TransitBillAddress;
        }

        public void CompleteSelfInfo()
        {
            SyncClass SyncClass_Instance = new SyncClass("CheckoutCSVItem", "CompleteSelfInfo", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<TransitBillCheckoutCSVItem>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(TransitBillCheckoutCSVItem f_CheckoutCSVItem)
        {
            this.CustomerInfo_List = f_CheckoutCSVItem.CustomerInfo_List;
            this.PackageInfo_List = f_CheckoutCSVItem.PackageInfo_List;
        }
    }
}
