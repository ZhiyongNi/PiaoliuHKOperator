using Newtonsoft.Json;
using PiaoliuHKOperator.Models.engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.core
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerRealName { get; set; }
        public int CustomerGender { get; set; }
        public string CustomerSelfMobile { get; set; }
        public string CustomerSelfDefaultAddress { get; set; }
        public string CustomerSelfDirectAddress { get; set; }
        public string CustomerSelfOtherAddress { get; set; }
        public string CustomerCollage { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerQQ { get; set; }
        public string CustomerWeixin { get; set; }
        public string CustomerAlipay { get; set; }
        public string CustomerAvatarMobile { get; set; }
        public string CustomerAvatarAddress { get; set; }
        public int CustomerAccountStatus { get; set; }

        public List<string> CustomerCell_Argument_List = new List<string>();

        public void updateCustomerArgumentInfo(List<string> f_Argument_List)
        {
            this.CustomerCell_Argument_List = f_Argument_List;
            SyncThisbyMethod("updateCustomerArgumentInfo");
        }
        public void addCustomerNewRecoder() { }

        private void setCustomerID() { }
        private void SyncThisbyMethod(string f_TargetMethod)
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().FullName, f_TargetMethod, JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();
            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<Customer>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(Customer f_Customer)
        {
            this.CustomerID = f_Customer.CustomerID;
            this.CustomerName = f_Customer.CustomerName;
            this.CustomerPassword = f_Customer.CustomerPassword;
            this.CustomerRealName = f_Customer.CustomerRealName;
            this.CustomerGender = f_Customer.CustomerGender;
            this.CustomerSelfMobile = f_Customer.CustomerSelfMobile;
            this.CustomerSelfDefaultAddress = f_Customer.CustomerSelfDefaultAddress;
            this.CustomerSelfDirectAddress = f_Customer.CustomerSelfDirectAddress;
            this.CustomerSelfOtherAddress = f_Customer.CustomerSelfOtherAddress;
            this.CustomerCollage = f_Customer.CustomerCollage;
            this.CustomerEmail = f_Customer.CustomerEmail;
            this.CustomerQQ = f_Customer.CustomerQQ;
            this.CustomerWeixin = f_Customer.CustomerWeixin;
            this.CustomerAlipay = f_Customer.CustomerAlipay;
            this.CustomerAvatarMobile = f_Customer.CustomerAvatarMobile;
            this.CustomerAvatarAddress = f_Customer.CustomerAvatarAddress;
            this.CustomerAccountStatus = f_Customer.CustomerAccountStatus;
        }
    }
}
