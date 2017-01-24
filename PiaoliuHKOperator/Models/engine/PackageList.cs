using Newtonsoft.Json;
using PiaoliuHKOperator.Models.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class PackageList
    {
        public String ExcuteCommand;
        public List<Package> PackageItemList = new List<Package>();
        public void findAllPackagebyFilter(string FilterString)
        {
            this.ExcuteCommand = FilterString;

            SyncClass SyncClass_Instance = new SyncClass("PackageList", "findAllPackagebyFilter", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<PackageList>(SyncClass_Instance.SyncJsonString));
            }



        }
        private void CloneThis(PackageList f_PackageList)
        {
            this.PackageItemList = f_PackageList.PackageItemList;
        }
    }
}
