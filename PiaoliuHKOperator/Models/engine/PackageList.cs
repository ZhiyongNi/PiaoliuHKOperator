using Newtonsoft.Json;
using PiaoliuHKOperator.Models.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class PackageList
    {
        public List<string> SQLExecuteArray;
        public List<Package> PackageItemList = new List<Package>();
        public void findALLPackagebyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;

            //SyncClass SyncClass_Instance = new SyncClass(this.GetType().FullName, "findALLPackagebyFilter", JsonConvert.SerializeObject(this));
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().Name, "findALLPackagebyFilter", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<PackageList>(SyncClass_Instance.SyncJsonString));
            }
        }
        public void findSIGNEDPackagebyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;

            SyncClass SyncClass_Instance = new SyncClass("PackageList", "findSIGNEDPackagebyFilter", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<PackageList>(SyncClass_Instance.SyncJsonString));
            }
        }
        public void findINSYSPackagebyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;

            SyncClass SyncClass_Instance = new SyncClass("PackageList", "findINSYSPackagebyFilter", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<PackageList>(SyncClass_Instance.SyncJsonString));
            }
        }

        private void CloneThis(PackageList f_PackageList)
        {
            this.SQLExecuteArray = f_PackageList.SQLExecuteArray;
            this.PackageItemList = f_PackageList.PackageItemList;
        }
    }
}
