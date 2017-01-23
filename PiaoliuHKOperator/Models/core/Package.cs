using System;
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
        public string PackageExpressCompany { get; set; }
        public string PackageExpressTrackNumber { get; set; }
        public string PackageSnapshot { get; set; }
        public float PackageWeight { get; set; }
        public float PackageFee { get; set; }
        public int PackageInTimeStamp { get; set; }
        public int PackageOutTimeStamp { get; set; }
        public int PackageStatus { get; set; }
        public string PackageRemarks { get; set; }
        public int PackageWorkerID { get; set; }
        public string PackageRelatedTransitBillSerialID { get; set; }


        public void findPackagebyExpressTrackNumber(string f_PackageExpressTrackNumber)
        {
            this.PackageExpressTrackNumber = f_PackageExpressTrackNumber;
            SyncClass SyncClass_Instance = new SyncClass("Package", "findPackagebyExpressTrackNumber", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<Package>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(Package f_Package)
        {
            this.PackageID = f_Package.PackageID;
        }
    }
}
