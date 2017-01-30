using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.core
{
    class TransitBill
    {
        public int TransitBillID { get; set; }
        public string TransitBillSerialID { get; set; }
        public int TransitBillOwnerID { get; set; }
        public string TransitBillRelatedPackageSerialID { get; set; }
        public int TransitBillRelatedPackageQuantity { get; set; }
        public float TransitBillPrice { get; set; }
        public int TransitBillMethod { get; set; }
        public string TransitBillAddress { get; set; }
        public int TransitBillSettlement { get; set; }
        public int TransitBillInitializationTimeStamp { get; set; }
        public int TransitBillSignTimeStamp { get; set; }
        public int TransitBillStatus { get; set; }

        private void CloneThis(TransitBill f_TransitBill)
        {
            this.TransitBillID = f_TransitBill.TransitBillID;
            this.TransitBillSerialID = f_TransitBill.TransitBillSerialID;
            this.TransitBillOwnerID = f_TransitBill.TransitBillOwnerID;
            this.TransitBillRelatedPackageSerialID = f_TransitBill.TransitBillRelatedPackageSerialID;
            this.TransitBillRelatedPackageQuantity = f_TransitBill.TransitBillRelatedPackageQuantity;
            this.TransitBillPrice = f_TransitBill.TransitBillPrice;
            this.TransitBillMethod = f_TransitBill.TransitBillMethod;
            this.TransitBillAddress = f_TransitBill.TransitBillAddress;
            this.TransitBillSettlement = f_TransitBill.TransitBillSettlement;
            this.TransitBillInitializationTimeStamp = f_TransitBill.TransitBillInitializationTimeStamp;
            this.TransitBillSignTimeStamp = f_TransitBill.TransitBillSignTimeStamp;
            this.TransitBillStatus = f_TransitBill.TransitBillStatus;
        }

    }
}
