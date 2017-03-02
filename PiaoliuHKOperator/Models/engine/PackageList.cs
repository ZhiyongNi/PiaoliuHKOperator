using Newtonsoft.Json;
using PiaoliuHKOperator.Models.core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class PackageList
    {
        public List<string> SQLExecuteArray { get; set; }
        public ObservableCollection<Package> PackageItemList { get; set; }

        public PackageList()
        {
            SQLExecuteArray = new List<string>();
            PackageItemList = new ObservableCollection<Package>();
        }
        public void findALLPackagebyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;
            SyncThisbyMethod("findALLPackagebyFilter");
        }
        public void findSIGNEDPackagebyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;
            SyncThisbyMethod("findSIGNEDPackagebyFilter");
        }
        public void findINSYSPackagebyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;
            SyncThisbyMethod("findINSYSPackagebyFilter");
        }

        private void SyncThisbyMethod(string f_TargetMethod)
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().FullName, f_TargetMethod, JsonConvert.SerializeObject(this));
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
