using Newtonsoft.Json;
using PiaoliuHKOperator.Models.core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class CheckoutItemListFactory
    {
        public IList<CheckoutItem> CheckoutItemList;

        public CheckoutItemListFactory(IList<TransitBill> TransitBill_SourceList)
        {
            CheckoutItemList = new List<CheckoutItem>();
            foreach (TransitBill TransitBill_Cell in TransitBill_SourceList)
            {
                CheckoutItem CheckoutItem_Instance = new CheckoutItem();
                CheckoutItem_Instance.TransitBillSerialID = TransitBill_Cell.TransitBillSerialID;
                CheckoutItem_Instance.TransitBillOwnerID = TransitBill_Cell.TransitBillOwnerID;
                CheckoutItem_Instance.TransitBillRelatedPackageQuantity = TransitBill_Cell.TransitBillRelatedPackageQuantity;
                CheckoutItem_Instance.TransitBillPrice = TransitBill_Cell.TransitBillPrice;
                CheckoutItem_Instance.TransitBillAddress = TransitBill_Cell.TransitBillAddress;
                CheckoutItemList.Add(CheckoutItem_Instance);
            }
        }

        public void CompleteALLItemInfo()
        {
            foreach (CheckoutItem CheckoutItem_Instance in CheckoutItemList)
            {
                CheckoutItem_Instance.FillupSelfInfo();
            }
        }
        public List<CheckoutItemLite> FlattenItemInfo()
        {
            List<CheckoutItemLite> CheckoutItemLite_List = new List<CheckoutItemLite>();

            foreach (CheckoutItem CheckoutItem_Instance in CheckoutItemList)
            {
                CheckoutItemLite CheckoutItemLite_Instance = new CheckoutItemLite();
                int Row = CheckoutItem_Instance.PackageInfo_List.Count / 8;
                for (int i = 0; i < Row + 1; i++)
                {
                    if (i * 8 < CheckoutItem_Instance.PackageInfo_List.Count)
                    {
                        CheckoutItemLite_Instance.PackageSerialID_1 = CheckoutItem_Instance.PackageInfo_List[i * 8].PackageSerialID;
                        CheckoutItemLite_Instance.PackageWeight_1 = CheckoutItem_Instance.PackageInfo_List[i * 8].PackageWeight;
                    }
                    if (i * 8 + 1 < CheckoutItem_Instance.PackageInfo_List.Count)
                    {
                        CheckoutItemLite_Instance.PackageSerialID_2 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 1].PackageSerialID;
                        CheckoutItemLite_Instance.PackageWeight_2 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 1].PackageWeight;
                    }
                    if (i * 8 + 2 < CheckoutItem_Instance.PackageInfo_List.Count)
                    {
                        CheckoutItemLite_Instance.PackageSerialID_3 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 2].PackageSerialID;
                        CheckoutItemLite_Instance.PackageWeight_3 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 2].PackageWeight;
                    }
                    if (i * 8 + 3 < CheckoutItem_Instance.PackageInfo_List.Count)
                    {
                        CheckoutItemLite_Instance.PackageSerialID_4 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 3].PackageSerialID;
                        CheckoutItemLite_Instance.PackageWeight_4 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 3].PackageWeight;
                    }
                    if (i * 8 + 4 < CheckoutItem_Instance.PackageInfo_List.Count)
                    {
                        CheckoutItemLite_Instance.PackageSerialID_5 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 4].PackageSerialID;
                        CheckoutItemLite_Instance.PackageWeight_5 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 4].PackageWeight;
                    }
                    if (i * 8 + 5 < CheckoutItem_Instance.PackageInfo_List.Count)
                    {
                        CheckoutItemLite_Instance.PackageSerialID_6 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 5].PackageSerialID;
                        CheckoutItemLite_Instance.PackageWeight_6 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 5].PackageWeight;
                    }
                    if (i * 8 + 6 < CheckoutItem_Instance.PackageInfo_List.Count)
                    {
                        CheckoutItemLite_Instance.PackageSerialID_7 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 6].PackageSerialID;
                        CheckoutItemLite_Instance.PackageWeight_7 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 6].PackageWeight;
                    }
                    if (i * 8 + 7 < CheckoutItem_Instance.PackageInfo_List.Count)
                    {
                        CheckoutItemLite_Instance.PackageSerialID_8 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 7].PackageSerialID;
                        CheckoutItemLite_Instance.PackageWeight_8 = CheckoutItem_Instance.PackageInfo_List[i * 8 + 7].PackageWeight;
                    }

                    CheckoutItemLite_Instance.TransitBillSerialID = CheckoutItem_Instance.TransitBillSerialID;
                    CheckoutItemLite_Instance.TransitBillOwnerID = CheckoutItem_Instance.TransitBillOwnerID;
                    if (CheckoutItem_Instance.CustomerInfo_List.Count == 0)
                    {
                        CheckoutItemLite_Instance.CustomerRealName = CheckoutItem_Instance.CustomerInfo_List[0].CustomerRealName;
                        CheckoutItemLite_Instance.CustomerSelfMobile = CheckoutItem_Instance.CustomerInfo_List[0].CustomerSelfMobile;
                    }
                    CheckoutItemLite_Instance.TransitBillRelatedPackageQuantity = CheckoutItem_Instance.TransitBillRelatedPackageQuantity; ;
                    CheckoutItemLite_Instance.TransitBillPrice = CheckoutItem_Instance.TransitBillPrice;
                    CheckoutItemLite_Instance.TransitBillAddress = CheckoutItem_Instance.TransitBillAddress;

                    CheckoutItemLite_List.Add(CheckoutItemLite_Instance);
                }
            }
            return CheckoutItemLite_List;
        }
    }
}
