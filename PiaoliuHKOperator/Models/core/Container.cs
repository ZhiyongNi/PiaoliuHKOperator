using Newtonsoft.Json;
using PiaoliuHKOperator.Models.engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.core
{
    class Container
    {
        public int ContainerID { get; set; }
        public string ContainerSerialID { get; set; }
        public int ContainerWorkerID { get; set; }
        public List<string> ContainerRelatedTransitBillSerialID { get; set; }
        public int ContainerRelatedTransitBillQuantity { get; set; }
        public string ContainerExpressCompany { get; set; }
        public string ContainerExpressTrackNumber { get; set; }
        public float ContainerPrice { get; set; }
        public int ContainerInitializationTimeStamp { get; set; }
        public int ContainerSignTimeStamp { get; set; }
        public int ContainerStatus { get; set; }

        public List<string> ContainerCell_Argument_List = new List<string>();

        public Container()
        {
            ContainerRelatedTransitBillSerialID = new List<string>();
        }
        public void addContainerNewRecoder()
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().Name, "addContainerNewRecoder", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<Container>(SyncClass_Instance.SyncJsonString));
            }
        }
        public void updateContainerRecoderbyArgumentInfo(List<string> f_Argument_List)
        {
            this.ContainerCell_Argument_List = f_Argument_List;
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().Name, "updateContainerRecoderbyArgumentInfo", JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<Container>(SyncClass_Instance.SyncJsonString));
            }
        }

        private void CloneThis(Container f_Container)
        {
            this.ContainerID = f_Container.ContainerID;
            this.ContainerSerialID = f_Container.ContainerSerialID;
            this.ContainerWorkerID = f_Container.ContainerWorkerID;
            this.ContainerRelatedTransitBillSerialID = f_Container.ContainerRelatedTransitBillSerialID;
            this.ContainerRelatedTransitBillQuantity = f_Container.ContainerRelatedTransitBillQuantity;
            this.ContainerExpressCompany = f_Container.ContainerExpressCompany;
            this.ContainerExpressTrackNumber = f_Container.ContainerExpressTrackNumber;
            this.ContainerPrice = f_Container.ContainerPrice;
            this.ContainerInitializationTimeStamp = f_Container.ContainerInitializationTimeStamp;
            this.ContainerSignTimeStamp = f_Container.ContainerSignTimeStamp;
            this.ContainerStatus = f_Container.ContainerStatus;
        }

    }
}
