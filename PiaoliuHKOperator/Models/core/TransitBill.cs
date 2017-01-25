using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.core
{
    class TransitBill
    {
        public int TransitBillID;

        public string TransitBillSerialID;

        public int TransitBillOwnerID;

        public string TransitBillRelatedPackageSerialID;

        public int TransitBillRelatedPackageQuantity;

        public float TransitBillPrice;

        public int TransitBillMethod;

        public string TransitBillAddress;

        public int TransitBillSettlement;

        public int TransitBillInitializationTimeStamp;

        public int TransitBillSignTimeStamp;

        public int TransitBillStatus;

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
