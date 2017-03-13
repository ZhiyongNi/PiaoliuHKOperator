using Newtonsoft.Json;
using PiaoliuHKOperator.Models.core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class ContainerList
    {
        public List<string> SQLExecuteArray { get; set; }
        public ObservableCollection<Container> ContainerItemList { get; set; }

        public ContainerList()
        {
            SQLExecuteArray = new List<string>();
            ContainerItemList = new ObservableCollection<Container>();
        }
        public void findAllContainerbyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;
            SyncThisbyMethod("findAllContainerbyFilter");
        }
        public void findSIGNEDContainerbyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;
            SyncThisbyMethod("findSIGNEDContainerbyFilter");
        }

        public void findINSYSContainerbyFilter(List<string> FilterArray)
        {
            this.SQLExecuteArray = FilterArray;
            SyncThisbyMethod("findINSYSContainerbyFilter");
        }

        private void SyncThisbyMethod(string f_TargetMethod)
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().FullName, f_TargetMethod, JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<ContainerList>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(ContainerList f_ContainerList)
        {
            this.SQLExecuteArray = f_ContainerList.SQLExecuteArray;
            this.ContainerItemList = f_ContainerList.ContainerItemList;
        }
    }
}
