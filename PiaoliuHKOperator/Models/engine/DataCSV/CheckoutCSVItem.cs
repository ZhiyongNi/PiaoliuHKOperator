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
    class CheckoutCSVItem
    {
        public string TransitBillSerialID { get; set; }
        public int TransitBillOwnerID { get; set; }
        public string CustomerRealName { get; set; }
        public string CustomerSelfMobile { get; set; }
        public List<string> TransitBillRelatedPackageSerialID_List { get; set; }
        public List<float> PackageWeight_List { get; set; }
        public int TransitBillRelatedPackageQuantity { get; set; }
        public float TransitBillPrice { get; set; }
        public string TransitBillAddress { get; set; }

        public CheckoutCSVItem()
        { }
        public CheckoutCSVItem(TransitBill f_TransitBill)
        {
            this.TransitBillSerialID = f_TransitBill.TransitBillSerialID;
            this.TransitBillOwnerID = f_TransitBill.TransitBillOwnerID;
            //this.TransitBillRelatedPackageSerialID = f_TransitBill.TransitBillRelatedPackageSerialID;
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
                CloneThis(JsonConvert.DeserializeObject<CheckoutCSVItem>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(CheckoutCSVItem f_CheckoutCSVItem)
        {
            this.CustomerRealName = f_CheckoutCSVItem.CustomerRealName;
            this.CustomerSelfMobile = f_CheckoutCSVItem.CustomerSelfMobile;
            this.TransitBillRelatedPackageSerialID_List = f_CheckoutCSVItem.TransitBillRelatedPackageSerialID_List;
            this.PackageWeight_List = f_CheckoutCSVItem.PackageWeight_List;
        }
    }
}
