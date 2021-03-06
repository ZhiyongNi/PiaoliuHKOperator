﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiaoliuHKOperator.Models.engine;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace PiaoliuHKOperator.Models.core
{
    public class Package
    {
        public int PackageID { get; set; }
        public string PackageSerialID { get; set; }
        public int PackageOwnerID { get; set; }
        public string PackageOwnerMobile { get; set; }
        public int PackageExpressCompany { get; set; }
        public string PackageExpressTrackNumber { get; set; }
        public string PackageSnapshot { get; set; }
        public float PackageWeight { get; set; }
        public float PackageFee { get; set; }
        public double PackageInTimeStamp { get; set; }
        public double PackageOutTimeStamp { get; set; }
        public int PackageStatus { get; set; }
        public string PackageRemarks { get; set; }
        public int PackageWorkerID { get; set; }
        public string PackageRelatedTransitBillSerialID { get; set; }

        public List<string> PackageCell_Argument_List { get; set; }

        public Package()
        {
            PackageCell_Argument_List = new List<string>();
        }
        public void updatePackageArgumentInfo(List<string> f_Argument_List)
        {
            this.PackageCell_Argument_List = f_Argument_List;
            SyncThisbyMethod("updatePackageArgumentInfo");
        }
        public void addPackageNewRecoder()
        {
            setPackageSerialNumber();
            SyncThisbyMethod("addPackageNewRecoder");
        }

        private void setPackageSerialNumber()
        {
            string SerialNumber = "PATEMP";
            this.PackageSerialID = SerialNumber;
        }
        private void SyncThisbyMethod(string f_TargetMethod)
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().FullName, f_TargetMethod, JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<Package>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(Package f_Package)
        {
            this.PackageID = f_Package.PackageID;
            this.PackageSerialID = f_Package.PackageSerialID;
            this.PackageOwnerID = f_Package.PackageOwnerID;
            this.PackageOwnerMobile = f_Package.PackageOwnerMobile;
            this.PackageExpressCompany = f_Package.PackageExpressCompany;
            this.PackageExpressTrackNumber = f_Package.PackageExpressTrackNumber;
            this.PackageSnapshot = f_Package.PackageSnapshot;
            this.PackageWeight = f_Package.PackageWeight;
            this.PackageFee = f_Package.PackageFee;
            this.PackageInTimeStamp = f_Package.PackageInTimeStamp;
            this.PackageOutTimeStamp = f_Package.PackageOutTimeStamp;
            this.PackageStatus = f_Package.PackageStatus;
            this.PackageRemarks = f_Package.PackageRemarks;
            this.PackageWorkerID = f_Package.PackageWorkerID;
            this.PackageRelatedTransitBillSerialID = f_Package.PackageRelatedTransitBillSerialID;
        }
    }
}
