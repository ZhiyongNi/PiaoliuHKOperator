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

        public int PackageOwnerID { get; set; }

        public int PackageOwnerMobile { get; set; }

        public int PackageExpressCompany { get; set; }

        public int PackageExpressTrackNumber { get; set; }

        public string PackageSnapshot { get; set; }

        public int PackageWeight { get; set; }

        public int PackageFare { get; set; }

        public int PackageInTimeStamp { get; set; }

        public int PackageOutTimeStamp { get; set; }

        public int PackageStatus { get; set; }

        public int PackageChannel { get; set; }

        public int PackageRemarks { get; set; }

        public void findPackagebyExpressTrackNumber(int f_PackageExpressTrackNumber)
        {
            this.PackageExpressTrackNumber = f_PackageExpressTrackNumber;
            SyncClass SyncClass_Instance = new SyncClass("Package", "findPackagebyExpressTrackNumber", JsonConvert.SerializeObject(this));
            //SyncClass_Instance.SyncbySocket();
            //CloneThis(JsonConvert.DeserializeObject<Package>(SyncClass_Instance.JsonString));


        }
        private void CloneThis(Package f_Package)
        {

        }
    }
}
